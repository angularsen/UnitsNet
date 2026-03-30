# PR #1544 Review: QuantityValue as Fractional Number

Great work on this PR — the architectural improvements (ConversionExpression, centralized UnitConverter, builder pattern, exact rational coefficients) are solid and we want to get this merged.

The main concern is the breaking change impact of replacing `double` with `QuantityValue` across the public API. We evaluated two approaches to mitigate this and implemented both to get empirical data.

---

## The problem

Without mitigation, ~60-70% of consumer code breaks on upgrade:

```csharp
double meters = length.Meters;          // ❌ won't compile (returns QuantityValue)
double ratio = len1 / len2;             // ❌ won't compile (returns QuantityValue)
Math.Round(length.Meters, 2);           // ❌ won't compile
SomeApi(length.Value);                  // ❌ won't compile
```

---

## Option A: Add implicit conversion `QuantityValue → double` (recommended)

Change one keyword in `QuantityValue.ConvertToNumber.cs`:

```csharp
// Before:
public static explicit operator double(QuantityValue value) => value.ToDouble();
// After:
public static implicit operator double(QuantityValue value) => value.ToDouble();
```

### Why it works

The PR is clean — **no generated operator takes `double`**. Every operator uses `QuantityValue` exclusively:

```csharp
Length operator *(QuantityValue left, Length right)
Length operator *(Length left, QuantityValue right)
Length operator /(Length left, QuantityValue right)
QuantityValue operator /(Length left, Length right)
```

With bidirectional implicit conversions (`double ↔ QuantityValue`), C# overload resolution prefers user-defined operators over built-in ones when both require one implicit conversion. So `QV + double` resolves to user-defined `QV + QV`, not built-in `double + double`.

### Verified empirically (branch `option-a-implicit-cast`)

We implemented this and built/tested the full solution:

- **Library code**: 1 line changed. **Zero compilation errors.**
- **Test code**: 101 `Assert.Equal(double, QuantityValue)` calls needed `(double)` casts to resolve xUnit overload ambiguity — a mechanical fix, not a behavioral change.
- **Build**: 0 errors, 0 warnings.
- **Tests**: **0 new failures** across ~51,900 tests.

The xUnit ambiguity is specific to `Assert.Equal`'s many overloads (including `DateTime`). Standard consumer code — method calls, assignments, operators, comparisons — is unaffected.

### Consumer code scenarios

| Scenario | Works? | Explanation |
|----------|--------|-------------|
| `double meters = length.Meters` | ✅ | Implicit conversion |
| `double ratio = len1 / len2` | ✅ | Operator returns `QV`, implicit converts |
| `Math.Round(length.Meters, 2)` | ✅ | Resolves to `Math.Round(double, int)` |
| `SomeDoubleApi(length.Meters)` | ✅ | Implicit conversion |
| `Length * double` | ✅ | `double` promotes to `QV`, uses `Length * QV` |
| `double x = double + QV` | ✅ | Operator returns `QV`, implicit converts for assignment |
| `var x = length.Meters` | ✅ | `x` is `QV` — implicitly converts wherever `double` is expected |

### Trade-offs

- `var x = length.Meters` infers `QuantityValue` — consumers see this in IDE tooltips. Not a functional issue (implicit conversion handles everything), but visible.
- Precision loss from `QuantityValue → double` is silent. This is the desired trade-off for most consumers. Those who want exact precision can stay on `QuantityValue` directly.
- Bidirectional implicit conversion is unusual in C#, but our empirical testing confirms it works cleanly here.

---

## Option B: Keep `double` public, use `QuantityValue` internally (not recommended)

Revert the public API to `double` while keeping `QuantityValue` for the internal conversion pipeline. We fully implemented this to evaluate the trade-offs.

### Verified empirically (branch `option-b-double-public`)

- **608 files changed**: ~10 manual source files, CodeGen templates (~15 locations), `UnitRelations.json`, all 131 generated quantities regenerated, serialization adapters, test and benchmark code.
- **Build**: 0 library errors, 0 warnings.
- **Tests**: **2,509 failures out of 51,899 (5%).**

### The failures are not test bugs

They reveal a fundamental precision loss from `double` storage:

| Failure category | Count | Root cause |
|-----------------|-------|------------|
| `ToUnit_FromNonBaseUnit` | 1,215 | Roundtrip conversion loses precision — `double` introduces rounding at each step |
| `ToUnit_FromIQuantity` | 491 | Same root cause |
| `ToString` | 256 | Precision-sensitive formatting |
| `ConversionRoundTrip` | 68 | Direct roundtrip tests |

With `QuantityValue`, converting `3.0 feet → meters → feet` is lossless (exact rational arithmetic). With `double` storage, each conversion step introduces floating-point rounding that compounds. **This defeats a core value proposition of the PR.**

---

## Comparison

| | Option A | Option B |
|---|---|---|
| Library code changes | 1 line | 608 files |
| Build errors | 0 | 0 |
| New test failures | 0 | 2,509 (5%) |
| Precision preserved | Full | Degraded (roundtrip loss) |
| Consumer breaking changes eliminated | ~60-70% | ~60-70% |
| Future flexibility | Consumers can use `QuantityValue` directly | Requires later API change |

## Recommendation

**Option A.** One line of library code, zero new test failures, full precision preserved. It eliminates the largest consumer-facing breaking change while keeping 100% of the PR's value.

---

## Other items to address before merge

### Must do

1. **Revert `EmitDefaultValue = false` on DataMember** — `Length.Zero` serialized via DataContract should always include both Value and Unit. @angularsen flagged this.

### Should do

2. **Document DataContract serialization as a breaking change** in v6 release notes. The `_value` field type change means existing DataContract-serialized data won't deserialize. XML surrogate works; JSON surrogate blocked by [.NET runtime bug](https://github.com/dotnet/runtime/issues/100553). Recommend migrating to JsonNet or System.Text.Json packages.

### Post-merge

3. **Migration guide** for this PR's breaking changes (to be expanded for full v6 later).
4. **Test coverage for `InterfaceQuantityWithUnitTypeConverter`** — appears unused/untested.
5. **Align `QuantityValueFormatOptions` enum names** — `DecimalPrecision` vs `ExactNumber` should use consistent naming.
6. **`Configure` extension on `UnitDefinition[]`** — consider wrapper type or static method for cleaner API.

### Remaining breaking changes (regardless of QuantityValue approach)

| Change | v5 | v6 |
|--------|-----|-----|
| `As()`, `ToUnit()` | Interface methods | Extension methods (some `[Obsolete]`) |
| `UnitConverter()` constructor | Public, parameterless | Removed |
| `SetConversionFunction` / `GetConversionFunction` | Available | Removed |
| `UnitsNetSetup` constructor | Public | Private; use builder |
| DataContract serialization | `double` field | `QuantityValue` struct |
| `AbbreviatedUnitsConverter` (JsonNet) | `IReadOnlyDictionary` ctor | `UnitParser` + options |
| Default JSON precision | ~17 digits | Up to 29 digits |
| `MissingMemberHandling.Error` | Silently skipped unknowns | Correctly throws (bug fix) |
| Null `IQuantity` deserialization | Returns `.Zero` | Returns `null` |
