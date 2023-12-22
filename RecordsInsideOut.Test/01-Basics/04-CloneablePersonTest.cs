using FluentAssertions;
using RecordsInsideOut._01_Basics;
using Xunit;

namespace RecordsInsideOut.Test._01_Basics;

public class _04_CloneablePersonTest
{
    [Fact]
    public void Work_With_Clonable_Person()
    {
        var person1 = new CloneablePerson("Charlie", "Chaplin");
        var person2 = person1.Clone();

        person1.Should().Be(person2); // Are equality equal
        person1.Should().NotBeSameAs(person2); // Are not reference equal
    }
}