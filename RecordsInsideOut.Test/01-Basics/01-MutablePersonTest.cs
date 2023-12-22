using FluentAssertions;
using RecordsInsideOut._01_Basics;
using Xunit;

namespace RecordsInsideOut.Test._01_Basics;

public class _01_MutablePersonTest
{
    [Fact]
    public void Work_With_Mutable_Person()
    {
        var person = new MutablePerson
        {
            FirstName = "Charli",
            LastName = "Chapplin",
        };
        person.FirstName.Should().Be("Charli");

        person.FirstName = "Charlie";
        person.FirstName.Should().Be("Charlie");
    }
}