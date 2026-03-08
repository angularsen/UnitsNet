# PR #1544 Review: QuantityValue as Fractional Number

**833 files changed**, +87,798 / -57,617 lines. Status: CLOSED (stale bot). Branch: `fractional-quantity-value`.

---

## 1. Breaking Changes (High Impact)

### 1a. `double` → `QuantityValue` everywhere (affects 100% of consumers)

The core value type changes from `double` to `QuantityValue` (BigInteger-backed rational). This touches every public API surface:

| API | Before | After |
|-----|--------|-------|
| `IQuantity.Value` | `double` | `QuantityValue` |
| `quantity.Meters` (all unit properties) | `double` | `QuantityValue` |
| `Length / Length` | `double` | `QuantityValue` |
| Constructors | `new Length(double, unit)` | `new Length(QuantityValue, unit)` |
| `From()` factories | `From(double, unit)` | `From(QuantityValue, unit)` |

**Implicit conversion FROM `double` TO `QuantityValue` exists**, so constructors and `From()` calls still compile. **But the reverse is explicit-only**, so:
```csharp
double meters = length.Value;       // ❌ won't compile
double meters = (double)length.Value; // ✅ explicit cast required
```

**Impact**: Every consumer accessing `.Value`, unit properties, or `As()` return values as `double` must add explicit casts. This is the single largest migration burden.

### 1b. `As()` and `ToUnit()` removed from interfaces

- `IQuantity.As(Enum)`, `IQuantity.As(UnitKey)`, `IQuantity.ToUnit(Enum)` — **removed from interface**
- `IQuantity<TUnit>.As(TUnit)`, `IQuantity<TUnit>.ToUnit(TUnit)` — **removed from interface**
- These are now **extension methods** in `QuantityExtensions`, with some marked `[Obsolete]`

**Impact**: Code calling these through interface references will need the extension method namespace (`using UnitsNet`). Reflection-based code and explicit interface implementations will break.

### 1c. `UnitConverter` completely redesigned

- Public constructor `UnitConverter()` — **removed**
- `SetConversionFunction()` / `GetConversionFunction()` — **removed**
- `ConversionFunction` / `ConversionFunction<T>` delegate types — **removed**
- `CreateDefault()` — **removed**
- New: `UnitConverter.Create(UnitParser, QuantityConverterBuildOptions)` factory
- Three internal implementations: `FrozenQuantityConverter`, `DynamicQuantityConverter`, `NoCachingConverter`

**Impact**: Anyone who registered custom conversions via `SetConversionFunction` must rewrite using the new builder API. This is a significant API change.

### 1d. `UnitsNetSetup` constructor now private

- `new UnitsNetSetup(IEnumerable<QuantityInfo>, UnitConverter)` — **removed**
- Replaced by builder pattern: `UnitsNetSetup.ConfigureDefaults(builder => ...)` and `UnitsNetSetup.Create(...)`

### 1e. DataContract serialization format completely changed

The `[DataMember]` field `_value` changed from `double` to `QuantityValue`, which means:
- **XML DataContract**: `<Value>1.2</Value>` → `<Value><N><_sign>12</_sign></N><D><_sign>10</_sign></D></Value>`
- **DataContractJsonSerializer**: `{"Value":1.2}` → `{"Value":{"N":{"_bits":null,"_sign":12},"D":{"_bits":null,"_sign":10}}}`

**No backward compatibility**. Existing persisted DataContract data cannot be deserialized. A `QuantityValueSurrogateSerializationProvider` is provided for XML, but the JSON surrogate doesn't work due to [a .NET runtime bug](https://github.com/dotnet/runtime/issues/100553).

### 1f. `AbbreviatedUnitsConverter` (JsonNet) constructor API changed

- Old constructor taking `IReadOnlyDictionary<string, QuantityInfo>` — **removed**
- New constructors take `UnitParser` and `QuantityValueFormatOptions`
- Several protected methods removed (breaks subclasses)

---

## 2. Behavioral Changes

### 2a. Arithmetic precision

All arithmetic is now arbitrary-precision rational instead of IEEE 754 double. Results will differ past the 15th significant digit. `0.1 + 0.2` will now equal exactly `0.3` (not `0.30000000000000004`).

### 2b. Default JSON serialization precision

The default `AbbreviatedUnitsConverter` now serializes with up to 29 significant digits (`DecimalPrecision`) instead of ~17. For `1.0/3.0`:
- Old: `0.333333333333333`
- New: `0.3333333333333333333333333333`

A `QuantityValueFormatOptions(DoublePrecision, RoundedDouble)` option exists for backward-compatible behavior.

### 2c. `MissingMemberHandling` in JsonNet converter

The new `AbbreviatedUnitsConverter` now throws on unknown JSON properties when `MissingMemberHandling != Ignore`. Previously, unknown properties were silently skipped.

### 2d. Null handling for `IQuantity` deserialization

Previously returned `quantityInfo.Zero` for null tokens. Now returns `null` for `IQuantity` or nullable types.

### 2e. Conversion functions are now exact rationals

Generated conversion factors like feet-to-meters are now exact fractions (e.g., `1250/381`) instead of floating-point approximations. This improves precision but may produce slightly different results in edge cases.

---

## 3. Public API Additions

### 3a. `QuantityValue` — new core type
- `readonly partial struct` implementing `INumber<QuantityValue>` on .NET 7+
- Full rational arithmetic, comparison, formatting
- `FromDoubleRounded()`, `FromTerms()`, `FromPowerOfTen()` factories
- `ToDouble()`, `ToDecimal()` conversion methods
- `Reduce()` for manual normalization

### 3b. `ConversionExpression` — declarative conversion model
- `readonly record struct` representing `f(x) = a * g(x)^n + b`
- Composable, optimizable conversion chain
- Replaces old `Func<double, double>` conversion functions

### 3c. `UnitInfo.ConversionFromBase` / `ConversionToBase`
- New properties exposing conversion logic directly on `UnitInfo`

### 3d. `UnitsNetSetup` builder API
- `ConfigureDefaults(Action<DefaultConfigurationBuilder>)`
- `Create(Action<DefaultConfigurationBuilder>)`
- Builder supports: `WithQuantities`, `WithAdditionalQuantities`, `ConfigureQuantity`, `WithConverterOptions`

### 3e. `UnitsNet.Serialization.SystemTextJson` — entirely new package
- `JsonQuantityConverter`, `AbbreviatedQuantityConverter`
- Multiple value converters: decimal, double, fractional notation, mixed
- `InterfaceQuantityConverterBase` for polymorphic `IQuantity` deserialization

### 3f. Extension methods for quantity operations
- `LinearQuantityExtensions`, `AffineQuantityExtensions`, `LogarithmicQuantityExtensions`
- `QuantityExtensions.As<TQuantity, TUnit>()`, `ToUnit<TQuantity, TUnit>()`

---

## 4. Code Issues

### 4a. Commented-out code (already flagged in review)
~125 lines of commented-out code identified by @angularsen's Claude review. lipchev has been addressing these. Most are fixed per the inline comment responses.

### 4b. XOR-based hash for `QuantityConversion`
Uses `hash1 ^ hash2` for commutative hashing. XOR is a weak hash combiner — any pair with the same type on both sides produces hash 0. In practice quantities in a conversion pair are always distinct, so this is low-risk but technically fragile.

### 4c. DataContractJsonSerializer with surrogates is non-functional
The `QuantityValueSurrogateSerializationProvider` doesn't work with `DataContractJsonSerializer` due to a .NET runtime bug. The test class is `internal` (disabled). This leaves no clean DataContract JSON story.

### 4d. `EmitDefaultValue = false` on DataMember
The `_value` and `_unit` fields now have `EmitDefaultValue = false`, which means `Length.Zero` serialized via DataContract will omit Value and Unit from the output. @angularsen flagged this as a concern — he prefers always including both fields.

---

## 5. Architectural Assessment

### 5a. Centralized converter (good)
Moving from per-quantity static conversion functions to a centralized `UnitConverter.Default` singleton is architecturally sound. It enables configurable caching strategies and cross-quantity conversion.

### 5b. ConversionExpression model (good)
Replacing compiled lambdas with composable `ConversionExpression` that can optimize and constant-fold is a significant improvement for maintainability and debuggability.

### 5c. Builder pattern for UnitsNetSetup (good)
The new builder API is cleaner than the old direct construction and enables partial loading of quantities.

### 5d. Performance
Per lipchev's benchmarks: Parse/TryParse ~60% faster, ToString ~75% faster, ToUnit ~60% slower (but +15ns absolute). Initialization is up to 10x slower but can be mitigated by loading fewer quantities. Rational arithmetic is within the same order of magnitude as `decimal`.

---

## 6. Recommendations — What to Fix Before Merging

Given we want to merge and defer minor things:

### Must-fix (high impact):
1. **`EmitDefaultValue = false` decision** — ✅ **DECISION: Revert to `EmitDefaultValue = true`** (remove the parameter). Safer, backward-compatible, explicit serialization output. Payload size savings are negligible.
2. **Clean remaining commented code** — ✅ **DECISION: Ask lipchev to clean all ~8 instances before merge.** Straightforward deletions, git history preserves everything. No shipping dead code in v6.
3. **DataContract backward compat story** — Document clearly that DataContract serialization is a breaking change with no automatic migration. Or provide a `QuantityValueSurrogate` approach that works for both XML and JSON.

### Should-discuss (architectural decision):
4. **Implicit conversion `QuantityValue` → `double`?** — Would reduce breaking changes from ~60-70% to ~20-30% of consumer code. Trade-off: hides precision loss. @angularsen asked about this; lipchev gave reasons against it. This is the single biggest migration friction point and worth a deliberate decision.

### Defer for post-merge:
- Roslyn analyzer for migration assistance
- Migration guide documentation
- `MissingMemberHandling` behavior change in JsonNet converter (minor)
- XOR hash in `QuantityConversion` (low risk)
- `InterfaceQuantityWithUnitTypeConverter` appears unused/untested per @angularsen's comment
- Various minor naming suggestions from review comments
