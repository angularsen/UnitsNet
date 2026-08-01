// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Modular;

/// <summary>
/// Marks the single interface that selects the quantities and units generated into a consumer-owned
/// assembly.
/// </summary>
/// <remarks>
/// <para>
/// Apply this attribute to one declarative interface in the project that will own the generated
/// quantity structs and unit enums. The interface is never instantiated or implemented. Instead,
/// inherit <see cref="IInclude{TQuantitySpec}" />, <see cref="IInclude{TQuantitySpec,TUnitSet}" />,
/// or <see cref="IIncludeProfile{TProfile}" /> to describe the generated API, then build the project.
/// </para>
/// <para>
/// A compilation can declare one module. Built-in quantities retain the familiar <c>UnitsNet</c>
/// namespace and their unit enums use <c>UnitsNet.Units</c> unless a target namespace is supplied.
/// Relationships such as <c>Length / Duration = Speed</c> are generated when every participating
/// quantity is selected. Do not reference the legacy <c>UnitsNet</c> package in the same project.
/// </para>
/// </remarks>
/// <example>
/// Select <c>Length</c>, <c>Duration</c>, and <c>Speed</c>, including all their units:
/// <code>
/// using UnitsNet.Modular;
/// using Catalog = UnitsNet.Modular.BuiltIns;
///
/// [UnitsNetModule]
/// internal interface ApplicationUnits :
///     IInclude&lt;Catalog.LengthSpec&gt;,
///     IInclude&lt;Catalog.DurationSpec&gt;,
///     IInclude&lt;Catalog.SpeedSpec&gt;;
/// </code>
/// After building, ordinary application code can use <c>UnitsNet.Length</c>,
/// <c>UnitsNet.Duration</c>, <c>UnitsNet.Speed</c>, and their unit enums.
/// </example>
/// <seealso href="https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Modular#quick-start">
/// UnitsNet.Modular quick start
/// </seealso>
/// <seealso href="https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Modular#configure-generation">
/// Complete module configuration
/// </seealso>
[AttributeUsage(AttributeTargets.Interface)]
public sealed class UnitsNetModuleAttribute : Attribute
{
    /// <summary>
    /// Creates a module that preserves each selected definition's declared namespace.
    /// </summary>
    public UnitsNetModuleAttribute()
    {
    }

    /// <summary>
    /// Creates a module that emits all selected quantities into <paramref name="targetNamespace" />.
    /// </summary>
    /// <param name="targetNamespace">
    /// The CLR namespace for generated quantity and unit-enum types. The compatibility namespace
    /// <c>UnitsNet</c> is special-cased so its unit enums use <c>UnitsNet.Units</c>.
    /// </param>
    public UnitsNetModuleAttribute(string targetNamespace) => TargetNamespace = targetNamespace;

    /// <summary>
    /// Gets the optional CLR namespace override applied to every selected quantity definition.
    /// </summary>
    public string? TargetNamespace { get; }
}

/// <summary>
/// Declares exact, glob, or regular-expression patterns used to select units from a quantity spec.
/// </summary>
/// <remarks>
/// Patterns match expanded invariant unit names, not abbreviations. Bare patterns use convenient
/// glob matching; prefix a pattern with <c>glob:</c> or <c>regex:</c> to select the matching mode
/// explicitly. The quantity's base unit is always included so every generated quantity remains
/// convertible. A unit set is selected through <see cref="IInclude{TQuantitySpec,TUnitSet}" />.
/// </remarks>
/// <example>
/// <code>
/// [UnitSet("Meter", "Millimeter", "Kilometer")]
/// internal interface CommonLengthUnits;
///
/// [UnitSet("regex:.*Meter$")]
/// internal interface MeterUnits;
/// </code>
/// </example>
/// <seealso href="https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Modular#filter-units">
/// Unit filtering documentation
/// </seealso>
[AttributeUsage(AttributeTargets.Interface)]
[CLSCompliant(false)]
public sealed class UnitSetAttribute : Attribute
{
    /// <summary>Creates a reusable unit selection from one or more unit-name patterns.</summary>
    /// <param name="patterns">
    /// Exact, glob, or <c>regex:</c>-prefixed patterns matched against invariant unit names.
    /// </param>
    public UnitSetAttribute(params string[] patterns) => Patterns = patterns;

    /// <summary>Gets the unit-name patterns used by this selection.</summary>
    public string[] Patterns { get; }
}

/// <summary>Binds a quantity spec interface to a stable semantic quantity ID.</summary>
/// <remarks>
/// Use this attribute when authoring a custom quantity or a definition package. The semantic ID
/// connects the spec to a <c>*.unitsnet.json</c> definition supplied as an
/// <c>AdditionalFiles</c> item. The recommended type name is the generated quantity name followed
/// by <c>Spec</c>. Published definition packages should expose public specs and keep their semantic
/// IDs stable; the package contributes definitions, while the consuming application owns the
/// generated quantity types.
/// </remarks>
/// <example>
/// <code>
/// [QuantitySpec("Contoso.Measurements.WidgetCount")]
/// public interface WidgetCountSpec;
///
/// [UnitsNetModule]
/// internal interface ApplicationUnits : IInclude&lt;WidgetCountSpec&gt;;
/// </code>
/// </example>
/// <seealso href="https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Modular#add-custom-quantities">
/// Custom quantity documentation
/// </seealso>
/// <seealso href="https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Modular#publish-a-definition-package">
/// Definition package documentation
/// </seealso>
[AttributeUsage(AttributeTargets.Interface)]
public sealed class QuantitySpecAttribute : Attribute
{
    /// <summary>Creates a binding to the semantic quantity ID <paramref name="semanticId" />.</summary>
    /// <param name="semanticId">
    /// The definition's stable namespace-qualified ID, such as
    /// <c>Contoso.Measurements.WidgetCount</c>.
    /// </param>
    public QuantitySpecAttribute(string semanticId) => SemanticId = semanticId;

    /// <summary>Gets the stable semantic quantity ID.</summary>
    public string SemanticId { get; }
}

/// <summary>Selects a quantity spec and all of its units for generation.</summary>
/// <typeparam name="TQuantitySpec">
/// A built-in spec from <c>UnitsNet.Modular.BuiltIns</c> or a custom interface marked with
/// <see cref="QuantitySpecAttribute" />.
/// </typeparam>
/// <remarks>
/// Inherit this interface from a <see cref="UnitsNetModuleAttribute" /> module or a reusable profile.
/// The spec type is an authoring input; the generator emits the corresponding quantity struct and
/// unit enum, not a concrete implementation of the spec interface.
/// </remarks>
/// <example>
/// <code>
/// [UnitsNetModule]
/// internal interface ApplicationUnits :
///     IInclude&lt;UnitsNet.Modular.BuiltIns.LengthSpec&gt;;
/// </code>
/// </example>
public interface IInclude<TQuantitySpec>
{
}

/// <summary>
/// Selects a quantity spec and the units matching <typeparamref name="TUnitSet" /> for generation.
/// </summary>
/// <typeparam name="TQuantitySpec">
/// A built-in or custom quantity spec.
/// </typeparam>
/// <typeparam name="TUnitSet">
/// An interface marked with <see cref="UnitSetAttribute" />.
/// </typeparam>
/// <remarks>
/// The base unit is generated even when none of the unit-set patterns select it, preserving a valid
/// conversion anchor. A direct filtered include on the module overrides a profile's selection for
/// the same quantity.
/// </remarks>
/// <example>
/// <code>
/// [UnitSet("Meter", "Kilometer")]
/// internal interface ApplicationLengthUnits;
///
/// [UnitsNetModule]
/// internal interface ApplicationUnits :
///     IInclude&lt;UnitsNet.Modular.BuiltIns.LengthSpec, ApplicationLengthUnits&gt;;
/// </code>
/// </example>
public interface IInclude<TQuantitySpec, TUnitSet>
{
}

/// <summary>Composes a reusable quantity-selection profile into a module or another profile.</summary>
/// <typeparam name="TProfile">
/// An interface that composes quantity specs, unit sets, or other profiles.
/// </typeparam>
/// <remarks>
/// Profiles provide reusable defaults. Direct quantity selections on the module override a profile's
/// unit selection for that quantity. Use
/// <c>UnitsNet.Modular.Profiles.AllQuantitiesProfile</c> when source compatibility with the complete
/// built-in catalog is preferred over a lean selection.
/// </remarks>
/// <example>
/// <code>
/// internal interface MechanicsProfile :
///     IInclude&lt;UnitsNet.Modular.BuiltIns.LengthSpec&gt;,
///     IInclude&lt;UnitsNet.Modular.BuiltIns.DurationSpec&gt;,
///     IInclude&lt;UnitsNet.Modular.BuiltIns.SpeedSpec&gt;;
///
/// [UnitsNetModule]
/// internal interface ApplicationUnits : IIncludeProfile&lt;MechanicsProfile&gt;;
/// </code>
/// </example>
/// <seealso href="https://github.com/angularsen/UnitsNet/tree/master/UnitsNet.Modular#use-profiles">
/// Profile documentation
/// </seealso>
public interface IIncludeProfile<TProfile>
{
}
