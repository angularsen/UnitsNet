using FluentAssertions;
using Xunit;

namespace UnitsNet.Core.Tests;

public class Class1
{
    [Fact]
    public void Foo()
    {
        Quantity.Infos.Should().ContainSingle().Which.Name.Should().Be("HowMuch");
    }
}
