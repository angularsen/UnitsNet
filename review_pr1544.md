# PR #1544 Review: QuantityValue as Fractional Number

**Review date**: 2026-03-09 | **Branch**: `fractional-quantity-value`

---

## Changes Required Before Merge

### P0 — Must do

1. **Add implicit conversion `QuantityValue` → `double`**
   Most consumers just want a `double`. Without this, ~60-70% of consumer code breaks on upgrade. With implicit conversion, that drops to ~20-30%. Those who want exact precision can still use `QuantityValue` directly.

2. **Revert `EmitDefaultValue = false` on DataMember**
   Remove the `EmitDefaultValue = false` parameter from `[DataMember]` on `_value` and `_unit` fields in generated quantities. `Length.Zero` should always serialize with both Value and Unit present.

### P1 — Should do

3. **Document DataContract serialization as a breaking change**
   State in v6 release notes that DataContract serialization format changed (XML and JSON). XML surrogate exists and works. DataContractJsonSerializer surrogate is blocked by a .NET runtime bug — recommend migrating to JsonNet or System.Text.Json packages.

---

## Deferred (Post-Merge)

### Before stable release

4. **Create migration guide** for breaking changes in this PR. Will need re-evaluation for full v6 migration guide later.
5. **Add test coverage for `InterfaceQuantityWithUnitTypeConverter`** — currently appears unused/untested.

### Low priority

6. **QuantityGenerator.cs** — Add example code comments in generated code sections for readability.
7. **QuantityValueFormatOptions.cs** — Align serialization/deserialization enum names (`DecimalPrecision` vs `ExactNumber` should use consistent naming).
8. **QuantityInfoBuilderExtensions** — `Configure` extension on `UnitDefinition[]` is awkward API; consider wrapper type or static method.

### Won't do

- Roslyn analyzer for migration assistance.

---

## Reference: Breaking Changes Summary

| Change | Before (v5) | After (v6) |
|--------|-------------|------------|
| `IQuantity.Value` | `double` | `QuantityValue` |
| Unit properties (e.g. `.Meters`) | `double` | `QuantityValue` |
| `Length / Length` | `double` | `QuantityValue` |
| `As()`, `ToUnit()` | Interface methods | Extension methods (some `[Obsolete]`) |
| `UnitConverter()` constructor | Public, parameterless | Removed; use `UnitConverter.Create(...)` |
| `SetConversionFunction` / `GetConversionFunction` | Available | Removed |
| `UnitsNetSetup` constructor | Public | Private; use builder pattern |
| DataContract serialization | `double` field | `QuantityValue` struct (numerator/denominator) |
| `AbbreviatedUnitsConverter` (JsonNet) | `IReadOnlyDictionary` constructor | `UnitParser` + `QuantityValueFormatOptions` |
| Default JSON precision | ~17 significant digits | Up to 29 significant digits |
| `MissingMemberHandling.Error` | Silently skipped unknowns | Now correctly throws (bug fix) |
| Null `IQuantity` deserialization | Returns `.Zero` | Returns `null` |
| Conversion factors | Floating-point approximations | Exact rational fractions |
