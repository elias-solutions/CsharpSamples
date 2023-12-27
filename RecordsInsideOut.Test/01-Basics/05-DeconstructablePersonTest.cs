using FluentAssertions;
using RecordsInsideOut._01_Basics;
using Xunit;

namespace RecordsInsideOut.Test._01_Basics;

public class _05_DeconstructablePersonTest
{
    [Fact]
    public void Work_With_Deconstructable_Person()
    {
        var person = new DeconstructablePerson("Charlie", "Chaplin");
        var (firstName, _) = person;

        firstName.Should().Be("Charlie");
    }
}

