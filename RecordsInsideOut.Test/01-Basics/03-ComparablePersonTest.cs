using FluentAssertions;
using RecordsInsideOut._01_Basics;
using Xunit;

namespace RecordsInsideOut.Test._01_Basics;

public class _03_ComparablePersonTest
{
    [Fact]
    public void Work_With_Comparable_Person()
    {
        var person1 = new ComparablePerson("Charlie", "Chaplin");
        var person2 = new ComparablePerson
        {
            FirstName = "Charlie", 
            LastName = "Chaplin"
        };

        person1.Should().Be(person2);
        person1.Should().NotBeSameAs(person2);
    }
}