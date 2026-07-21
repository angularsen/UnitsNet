# UnitsNetGen prototype implementation plan

This plan tracks the compatibility, catalog-composition, shared-contract, definition-package, and
relationship experiments. The representative sample keeps iteration fast, while the AllSi sample
keeps the broader SI relationship chain continuously buildable.

## Branches

- Steps 0–5: `agl/unitsnetgen-poc`
- Steps 6–7: a numeric/interoperability branch created from the completed step-5 commit

## Progress

- [x] **0. Add focused representative and AllSi catalog scenarios**
  - Keep Length, Area, Temperature, TemperatureDelta, Level, and Information as the fast
    representative selection.
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
  - Have UnitsNetGen quantities implement the shared contract.
  - Keep UnitsNet v6 adoption on a separate integration branch so this prototype can merge without
    changing the existing UnitsNet project or package.
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
  - Filter operators with selected semantic quantities while retaining private access to relation
    anchor conversions.

- [x] **8. Establish consumer-owned generation and definition packages**
  - Put stable authoring attributes and selection interfaces in the UnitsNetGen runtime instead of
    emitting public copies into every compilation.
  - Treat third-party packages as definition providers: JSON, localizations, relations, and public
    definition markers, but no compiled quantity structs.
  - Recommend one consumer-owned units library as the generation boundary shared by an application.
  - Target the runtime and shared Core contracts at modern .NET 8, 9, and 10; keep the analyzer
    itself on `netstandard2.0` only for compiler-host compatibility.

- [x] **9. Harden generator correctness and compatibility**
  - Add generator-driver tests for diagnostics, generated source, relationships, and incrementality.
  - Fix inverse relationship emission and diagnose ambiguous generated members.
  - Parse case-significant abbreviations with one longest-suffix-first lookup.
  - Preserve UnitsNet's stable built-in enum values and stable full-definition ordinals for custom
    quantities.
  - Remove generated substitutes for legacy `UnitsNet.IQuantity` interfaces while retaining concrete
    source compatibility and the shared `UnitsNet.Core` contract.
  - Keep the instance contract minimal, with static quantity identity, base unit, and construction
    on a modern self-typed composite interface.

- [x] **10. Make generation genuinely incremental and diagnostic-friendly**
  - Discover modules with `ForAttributeWithMetadataName`.
  - Extract value-equatable module requests instead of carrying Roslyn symbols through the pipeline.
  - Diagnose definition collisions and attach module or additional-file locations where possible.
  - Keep output deterministic regardless of include or pattern ordering.

- [x] **11. Generate relationships across definition namespaces**
  - Resolve relation endpoints globally by stable semantic quantity ID.
  - Separate semantic IDs from generated CLR namespaces and names.
  - Let selected quantities control relationship availability without requiring relation anchor units
    to be part of the public unit selection.
  - Emit operators on a deterministic locally generated operand and diagnose relationships that
    cannot be represented.
  - Accept an unambiguous structured relation format for third-party definitions while retaining the
    existing UnitsNet relation catalog as an input format.

- [x] **12. Demonstrate the application-owned units-library workflow**
  - Add a definition-only third-party package for the fictional HowMuch quantities.
  - Add a shared application units library that selects built-in and third-party definitions.
  - Add two consumers that reference the same generated library and therefore share CLR type identity.
  - Document that independently generated application modules intentionally have different CLR type
    identities.

- [x] **13. Share quantity capability contracts and algorithms**
  - Adapt UnitsNet's modern linear, affine, and logarithmic interface split into the clean Core
    contracts without legacy metadata or runtime setup dependencies.
  - Add generic construction, conversion, and default `ToUnit` behavior to the self-typed contract.
  - Keep instance `As`/`ToUnit` APIs while exposing static conversion for generic algorithms without
    a global lookup.
  - Reuse `Sum` and `Average` across UnitsNet and UnitsNetGen linear quantities.
  - Classify generated arithmetic from logarithmic and affine definition metadata.
  - Treat a default generated struct as zero in its base unit, matching UnitsNet behavior.

- [x] **14. Guard module ownership and complete affine semantics**
  - Diagnose multiple module markers before they emit colliding source.
  - Require an affine quantity's linear offset companion with an actionable diagnostic.
  - Generate quantity/offset addition and subtraction in both concrete implementations.
  - Share target-unit affine averaging without treating logarithmic averages as linear arithmetic.

- [x] **15. Establish comprehensive compatibility gates**
  - Compare complete declared public surfaces for representative linear, affine, and logarithmic
    quantities, with every deliberate difference recorded explicitly.
  - Compile a shared concrete-consumer source corpus against UnitsNet and UnitsNetGen.
  - Compare conversion, parsing, formatting, equality, default-value, exception, and arithmetic
    behavior rather than checking signatures alone.
  - Keep the shared Core experiment separate from compatibility with an unmodified UnitsNet
    package.

- [x] **16. Restore and validate the complete built-in catalog**
  - Embed all UnitsNet quantity definitions without maintaining a second handwritten inventory.
  - Generate all built-in marker types and make `AllQuantities` cover the complete catalog.
  - Preserve stable unit enum values and process the complete relationship catalog.
  - Keep the representative and focused SI profiles for fast iteration.
  - Measure full-catalog generation time, generated source size, and incremental rebuild behavior.

- [x] **17. Close concrete API and extension-method compatibility gaps**
  - Generate immutable `Units`, base-dimension, abbreviation, and unit parsing APIs.
  - Add common formatting overloads, non-generic comparison, and same-quantity division.
  - Expose `Sum`, `Average`, selector, target-unit, absolute-value, and tolerance operations through
    familiar extension syntax while retaining Core implementations.
  - Add explicit recipe augmentations for high-value handwritten quantity APIs instead of silently
    claiming complete compatibility.
  - Keep built-in augmentation selection and quantity dependencies in immutable recipe data rather
    than semantic-ID conditionals in the quantity emitter.

- [x] **18. Generate an immutable consumer-owned module registry**
  - Emit one registry for the selected module with semantic quantity IDs, units, abbreviations,
    base dimensions, construction, conversion, parsing, and formatting metadata.
  - Support dynamic operations over only the quantities owned by that consumer module.
  - Do not model the registry around mutable global conversion defaults or legacy setup types.

- [x] **19. Review registry and legacy compatibility**
  - Reassess which legacy interfaces and dynamic APIs consumers genuinely need after the immutable
    registry is usable.
  - Decide whether any compatibility belongs in Core, generated source, adapters, or remains
    unsupported.
  - Treat this as a design checkpoint; do not assume a compatibility facade.
  - Keep common read-only dynamic workflows on the immutable registry.
  - Generate a thin owner-scoped `Quantity` facade returning `UnitsNet.Core.IQuantity<double>` for
    familiar static call shapes.
  - Keep application-specific runtime policy in explicit adapters; do not generate a mutable legacy
    facade.
  - Document the workflow-by-workflow decision in `MIGRATION.md` and validate representative
    migrations against UnitsNet.

- [x] **20. Add catalog-wide validation and hardening**
  - Run API and behavioral checks across the complete generated catalog.
  - Establish the serialization direction using the immutable registry.
  - Validate trimming, Native AOT, supported target frameworks, analyzer loading, and deterministic
    generation.
  - Document measured compatibility and explicit non-goals.

## Deferred

- Complete permanent profile taxonomy beyond `AllQuantities`, the representative profile, and the
  focused SI profile.
- Application-specific runtime-policy adapters, when concrete use cases justify them.
- Canonical precompiled third-party quantity modules and operators between independently compiled
  module packages.
