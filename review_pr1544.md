# PR #1544 Review: QuantityValue as Fractional Number

**Review date**: 2026-03-09, updated 2026-03-26 | **Branch**: `fractional-quantity-value`

---

## P0 — Reducing the breaking change impact of `QuantityValue`

The PR replaces `double` with `QuantityValue` (BigInteger-backed rational) across the entire public API. Without mitigation, ~60-70% of consumer code breaks on upgrade. We propose two alternative solutions.

### Summary

| | Option A: Add implicit cast | Option B: Keep `double` public |
|---|---|---|
| **Approach** | Add `implicit operator double(QuantityValue)` | Revert public API to `double`, use `QuantityValue` internally for conversions |
| **Rework effort** | 1 line library code + 101 test fixes (mechanical) | Multi-day: ~10 source files, CodeGen templates, 131 regenerated files, serialization rework |
| **PR value preserved** | 100% | ~90% |
| **Consumer breaking changes** | Eliminated for ~60-70% of code | Eliminated for ~60-70% of code |
| **Precision model** | Consumers store and pass `QuantityValue` (full precision until they convert to `double`) | Consumers always work with `double`; precision only during conversion pipeline |
| **Risk** | Verified: 0 library build errors, 0 new test failures | Not implemented; significant risk of cascading issues in serialization layer |
| **`var x = len.Meters`** | `x` is `QuantityValue` (but implicitly converts to `double` wherever needed) | `x` is `double` |
| **Future flexibility** | Consumers who want exact precision can use `QuantityValue` directly today | Would require a later API change to expose `QuantityValue` to consumers |

**Our recommendation: Option A.** Empirically verified: 1 line of library code changed, 0 build errors, 0 new test failures across ~51,900 tests. Option B achieves the same consumer-facing goal but requires multi-day rework with no additional benefit.

---

## Option A: Add implicit conversion `QuantityValue → double`

### What changes

One line added to `QuantityValue.ConvertToNumber.cs`:

```csharp
public static implicit operator double(QuantityValue value) => value.ToDouble();
```

The existing `explicit` keyword changes to `implicit`. Everything else in the PR stays as-is.

### Why it works

The PR is clean — **no generated operator takes `double`**. Every operator uses `QuantityValue`:

```csharp
// Generated operators (e.g. Length.g.cs):
Length operator *(QuantityValue left, Length right)
Length operator *(Length left, QuantityValue right)
Length operator /(Length left, QuantityValue right)
QuantityValue operator /(Length left, Length right)
```

`QuantityValue` arithmetic operators are all `(QuantityValue, QuantityValue)` — no mixed-type overloads.

With bidirectional implicit conversions (`double ↔ QuantityValue`), C# overload resolution prefers user-defined operators over built-in ones when both require one conversion. So `QV + double` resolves to user-defined `QV + QV` (promoting `double`), not built-in `double + double` (demoting `QV`).

### Scenario analysis

| Scenario | Works? | Explanation |
|----------|--------|-------------|
| `double meters = length.Meters` | Yes | `QuantityValue` implicitly converts to `double` |
| `double ratio = len1 / len2` | Yes | Operator returns `QV`, implicit converts to `double` |
| `Math.Round(length.Meters, 2)` | Yes | Resolves to `Math.Round(double, int)` via implicit |
| `SomeDoubleApi(length.Meters)` | Yes | Implicit conversion handles the call |
| `Length * double` | Yes | `double` promotes to `QV`, uses `Length * QV` operator |
| `QV + double` | Yes | C# prefers user-defined `QV+QV` over built-in `double+double` |
| `double x = double + QV` | Yes | Operator returns `QV`, implicit converts for assignment |
| `var x = length.Meters` | `x` is `QV` | Not a problem — `QV` implicitly converts wherever `double` is expected |
| `QV == double` | Yes | User-defined `QV==QV` is preferred by C# overload resolution |

### Pros

- **Minimal rework** — one operator change, rest of PR untouched
- **Preserves 100% of PR value** — all architecture, all new features
- **Future-proof** — consumers who want exact precision can use `QuantityValue` directly; those who don't never notice the difference
- **Gradual adoption** — consumers can migrate to `QuantityValue` at their own pace

### Cons

- **Bidirectional implicit conversion is unusual** — while our analysis found no issues, there may be edge cases in consumer code we can't predict (e.g. complex overload resolution scenarios)
- **`var` infers `QuantityValue`** — not a functional problem (implicit conversion kicks in), but consumers see `QuantityValue` in IDE tooltips, debugger, etc.
- **Silent precision loss** — converting `QuantityValue` to `double` is lossy, and implicit makes it invisible. This is the *desired* trade-off for most consumers, but purists may object.
- **lipchev has stated this is a "no-go"** — may need to be verified empirically by building locally with the change

### Verified empirically

We implemented Option A on branch `option-a-implicit-cast` and built/tested the full solution.

**Results:**
- **Library code**: 1 line changed (`explicit` → `implicit` in `QuantityValue.ConvertToNumber.cs`). **Zero library compilation errors.**
- **Test code**: 101 `Assert.Equal(double, QuantityValue)` calls needed `(double)` casts to resolve xUnit overload ambiguity. This is a mechanical fix — the test semantics are unchanged.
- **Build**: 0 errors, 0 warnings across all projects.
- **Tests**: 0 new failures. All ~51,900 tests pass. (4 pre-existing failures on the base PR branch are unrelated: locale-dependent `ConversionExpression.ToString` and custom quantity serialization registration.)

The only issue found was xUnit `Assert.Equal` overload ambiguity when one argument is `double` and the other is `QuantityValue`. This is an xUnit-specific quirk (many overloads including `DateTime`), not a general C# problem. Consumer code using standard method calls, assignments, and operators is unaffected.

---

## Option B: Keep `double` public, use `QuantityValue` internally

### What changes

- `IQuantity.Value` reverts to `double`
- Generated quantity unit properties (`.Meters`, `.Centimeters`, etc.) revert to `double`
- Generated quantity `_value` field reverts to `double`
- Scalar operators revert to `double` (`Length * double`, `Length / Length → double`)
- `From()` factory methods accept `double`
- `QuantityValue` remains as an internal type used by the conversion pipeline
- `ConversionExpression`, `UnitConverter`, `UnitsNetSetup` builder — all unchanged

### How the conversion pipeline works

```
double input → QuantityValue(input) × exact_rational_coefficient → .ToDouble() → double output
```

The precision benefit is preserved: conversion factors like `1250/381` (feet-to-meters) are exact rationals. The stored value is `double`, and the conversion pipeline temporarily promotes to `QuantityValue` for exact arithmetic, then converts back.

### What's preserved from the PR (~90%)

| Component | Status |
|-----------|--------|
| `QuantityValue` type (BigInteger rational) | Preserved for internal use |
| `ConversionExpression` model with exact rational coefficients | Fully preserved |
| `UnitConverter` / `FrozenQuantityConverter` / `DynamicQuantityConverter` | Fully preserved |
| `UnitInfo.ConversionFromBase` / `ConversionToBase` | Fully preserved |
| `UnitsNetSetup` builder pattern | Fully preserved |
| CodeGen rational coefficient generation | Fully preserved |
| `UnitsNet.Serialization.SystemTextJson` package | Preserved |

### What's lost (~10%)

- Consumers cannot work with `QuantityValue` directly — no exact precision in user-facing code
- Intermediate arithmetic between quantities uses `double`, not rationals (precision only in conversion factors)
- Would require a later API change to expose `QuantityValue` to consumers who want it

### Pros

- **Zero risk** — `double` public API is well-understood, no edge cases
- **No consumer breaking changes from the type change** — all `double`-based code works as before
- **Familiar to consumers** — no new type to learn about
- **Smaller memory footprint** — `double` is 8 bytes vs `QuantityValue` (16+ bytes for two BigInteger fields)

### Cons

- **Significant rework** — CodeGen templates, generated types, interface definitions all need adjustment
- **Loses future flexibility** — consumers can't access `QuantityValue` precision without a later API change
- **Precision only in conversion pipeline** — consumer arithmetic (`length1 + length2`) uses `double`, not rationals
- **~10% of PR value lost** — the `QuantityValue`-as-public-type feature and its test coverage

### Implementation scope (assessed, not implemented)

Option B was scoped but not implemented due to the scale of changes required:

- **~10 manual source files**: `IQuantity.cs`, `IArithmeticQuantity.cs`, `ILogarithmicQuantity.cs`, `QuantityExtensions.cs`, `QuantityParser.cs`, `Quantity.cs`, `UnitConverter.cs` (public signatures), `Comparison.cs`, plus custom quantity extras
- **CodeGen templates**: ~15 locations in `QuantityGenerator.cs`, plus `NumberExtensionsGenerator.cs`, `NumberExtensionsCS14Generator.cs`, `QuantityRelationsParser.cs`
- **Data files**: `UnitRelations.json` type reference
- **Regeneration**: All 131 quantity files + number extensions + test base classes
- **Serialization layer rework**: Serializers currently read/write `QuantityValue` from `IQuantity.Value` — changing to `double` fundamentally changes the wire format
- **Estimated effort**: Multi-day, with significant risk of cascading issues in serialization

Given that Option A achieves the same consumer-facing goal with 1 line of library code changed, Option B is not recommended unless Option A proves unworkable in practice.

---

## Other Changes Required Before Merge

### P1 — Must do

1. **Revert `EmitDefaultValue = false` on DataMember**
   Remove the `EmitDefaultValue = false` parameter from `[DataMember]` on `_value` and `_unit` fields in generated quantities. `Length.Zero` should always serialize with both Value and Unit present.

### P2 — Should do

2. **Document DataContract serialization as a breaking change**
   State in v6 release notes that DataContract serialization format changed (XML and JSON). XML surrogate exists and works. DataContractJsonSerializer surrogate is blocked by a .NET runtime bug — recommend migrating to JsonNet or System.Text.Json packages.

---

## Deferred (Post-Merge)

### Before stable release

3. **Create migration guide** for breaking changes in this PR. Will need re-evaluation for full v6 migration guide later.
4. **Add test coverage for `InterfaceQuantityWithUnitTypeConverter`** — currently appears unused/untested.

### Low priority

5. **QuantityGenerator.cs** — Add example code comments in generated code sections for readability.
6. **QuantityValueFormatOptions.cs** — Align serialization/deserialization enum names (`DecimalPrecision` vs `ExactNumber` should use consistent naming).
7. **QuantityInfoBuilderExtensions** — `Configure` extension on `UnitDefinition[]` is awkward API; consider wrapper type or static method.

### Won't do

- Roslyn analyzer for migration assistance.
- Commented code cleanup (already mostly done, 6 lines remain in CodeGen internal code).

---

## Reference: Remaining Breaking Changes

These apply regardless of which option is chosen for `QuantityValue`:

| Change | Before (v5) | After (v6) |
|--------|-------------|------------|
| `As()`, `ToUnit()` | Interface methods | Extension methods (some `[Obsolete]`) |
| `UnitConverter()` constructor | Public, parameterless | Removed; use `UnitConverter.Create(...)` |
| `SetConversionFunction` / `GetConversionFunction` | Available | Removed |
| `UnitsNetSetup` constructor | Public | Private; use builder pattern |
| DataContract serialization | `double` field | Changed format |
| `AbbreviatedUnitsConverter` (JsonNet) | `IReadOnlyDictionary` constructor | `UnitParser` + `QuantityValueFormatOptions` |
| Default JSON precision | ~17 significant digits | Up to 29 significant digits |
| `MissingMemberHandling.Error` | Silently skipped unknowns | Now correctly throws (bug fix) |
| Null `IQuantity` deserialization | Returns `.Zero` | Returns `null` |
| Conversion factors | Floating-point approximations | Exact rational fractions |
