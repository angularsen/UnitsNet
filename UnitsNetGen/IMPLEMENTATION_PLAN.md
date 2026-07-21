# UnitsNetGen prototype implementation plan

This plan tracks the compatibility, catalog-composition, shared-contract, numeric-storage, and
interoperability experiments. The representative sample keeps iteration fast, while the AllSi sample
keeps the broader SI relationship chain continuously buildable.

## Branches

- Steps 0–5: `agl/unitsnetgen-poc`
- Steps 6–7: a numeric/interoperability branch created from the completed step-5 commit

## Progress

- [x] **0. Add focused representative and AllSi catalog scenarios**
  - Keep Length, Area, Temperature, Level, and Information as the fast representative selection.
  - Include the Length, Mass, Duration, Area, Speed, Acceleration, Force, Pressure, Energy, and Power
    SI relationship chain.
  - Keep HowMuch as the custom third-party definition.
  - Read the retained built-ins from their real `Common/UnitDefinitions` JSON definitions.
  - Preserve unit filtering, localization, prefix expansion, affine conversion, logarithmic behavior,
    and conditional cross-quantity relationships.
  - Do not modify or delete the UnitsNet v6 catalog.

- [x] **1. Add linked-source compatibility consumers**
  - Add separate UnitsNet and UnitsNetGen console projects.
  - Link the exact same consumer scenario into both projects.
  - Keep provider-specific module/bootstrap code outside the linked source.
  - Make both projects independently runnable and package-update friendly.

- [x] **2. Implement source/API compatibility for the exercised catalog**
  - Generate the compatibility quantities in the `UnitsNet` namespace.
  - Match the selected UnitsNet factories, properties, conversions, parsing, formatting, and
    interfaces needed by the shared consumer.
  - Add an automated public-API compatibility comparison for the exercised surface.

- [x] **3. Add catalog profiles and selection precedence**
  - Add an explicit `IIncludeProfile<TProfile>` composition marker.
  - Generate `AllQuantities` and `AllSi` profiles for reusable catalog selections.
  - Make direct per-quantity unit selection override profile defaults.
  - Prove that consumer-defined profiles compose with individual includes.

- [x] **4. Introduce shared abstractions/Core**
  - Add the smallest stable quantity/unit contracts justified by the compatibility sample.
  - Have both UnitsNet v6 and UnitsNetGen quantities implement the shared contract.
  - Keep existing UnitsNet public interfaces in place; do not move public types between assemblies in
    this prototype.

- [x] **5. Verify and document the compatibility architecture**
  - Build and run both linked-source consumers.
  - Run generator/runtime tests for all retained behavior.
  - Document source, contract, data, and binary compatibility boundaries.

- [ ] **6. Add configurable numeric storage on a child branch**
  - Keep `double` as the default compatibility mode.
  - Prototype `decimal` and `Fraction` module specializations.
  - Diagnose conversions or arithmetic unsupported by the selected numeric type.

- [ ] **7. Add explicit cross-value interoperability bridges**
  - Introduce stable semantic quantity identity and base-value transfer contracts.
  - Support explicit checked and approximate numeric conversion policies.
  - Demonstrate a generic library consuming different generated representations.
  - Document why concrete generated structs in different assemblies are not assignment-compatible.

- [x] **Follow-up: replace hardcoded relationships with catalog data**
  - Embed `Common/UnitRelations.json` as the built-in relationship source of truth.
  - Generate commutative multiplication and inferred division overloads using the catalog rules.
  - Accept custom `UnitsNetGenRelation` files through compiler `AdditionalFiles`.
  - Filter operators with the selected quantities, canonical units, and generated namespace.

## Deferred

- Restore and validate the full UnitsNet quantity catalog.
- Define the complete permanent set of built-in quantity profiles.
- Run catalog-wide API compatibility, generator performance, and output-size measurements.
