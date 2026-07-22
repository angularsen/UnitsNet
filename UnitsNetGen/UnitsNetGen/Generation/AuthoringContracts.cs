// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNetGen.Generation;

/// <summary>Marks an interface as the generation boundary for a consumer-owned quantity module.</summary>
[AttributeUsage(AttributeTargets.Interface)]
public sealed class UnitsNetModuleAttribute : Attribute
{
    /// <summary>Creates a module that preserves each definition's declared namespace.</summary>
    public UnitsNetModuleAttribute()
    {
    }

    /// <summary>Creates a module that emits all selected quantities into <paramref name="targetNamespace" />.</summary>
    public UnitsNetModuleAttribute(string targetNamespace) => TargetNamespace = targetNamespace;

    /// <summary>Gets the optional CLR namespace override for generated quantities.</summary>
    public string? TargetNamespace { get; }
}

/// <summary>Declares glob or regular-expression patterns used to select public units.</summary>
[AttributeUsage(AttributeTargets.Interface)]
public sealed class UnitSetAttribute : Attribute
{
    /// <summary>Creates a reusable unit selection.</summary>
    public UnitSetAttribute(params string[] patterns) => Patterns = patterns;

    /// <summary>Gets the unit-name patterns.</summary>
    public string[] Patterns { get; }
}

/// <summary>Binds a public marker type from a definition package to a semantic quantity ID.</summary>
[AttributeUsage(AttributeTargets.Interface)]
public sealed class QuantityDefinitionAttribute : Attribute
{
    /// <summary>Creates a definition marker for <paramref name="id" />.</summary>
    public QuantityDefinitionAttribute(string id) => Id = id;

    /// <summary>Gets the stable semantic quantity ID.</summary>
    public string Id { get; }
}

/// <summary>Selects all units from a quantity definition.</summary>
public interface IInclude<TQuantityDefinition>
{
}

/// <summary>Selects units matching <typeparamref name="TUnitSet" /> from a quantity definition.</summary>
public interface IInclude<TQuantityDefinition, TUnitSet>
{
}

/// <summary>Composes a reusable quantity-selection profile into a module.</summary>
public interface IIncludeProfile<TProfile>
{
}
