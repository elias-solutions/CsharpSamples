using FluentAssertions;
using RecordsInsideOut._01_Basics;
using Xunit;

namespace RecordsInsideOut.Test._01_Basics;

public class _02_ImmutablePersonTest
{
    [Fact]
    public void Work_With_Mutable_Person()
    {
        var person = new ImmutablePerson("Charli", "Chaplin");
        person.FirstName.Should().Be("Charli");

        // That doesn't work.
        //person.FirstName = "Charlie";
        //person.FirstName.Should().Be("Charlie");
    }
}