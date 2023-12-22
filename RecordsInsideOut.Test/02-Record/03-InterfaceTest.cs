using FluentAssertions;
using RecordsInsideOut._02_Record;
using Xunit;

namespace RecordsInsideOut.Test._02_Record;

public class _03_InterfaceTest
{
    [Fact]
    public void _03_Work_With_Record_Interface()
    {
        var person = new PersonWithInterface("John", "Doe");
        var student = new StudentWithInterface("Charlie", "Chaplin", "XYZ");

        IPerson[] persons = { person, student };

        persons.Should().BeOfType<IPerson[]>();
    }
}