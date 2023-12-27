using FluentAssertions;
using RecordsInsideOut._02_Record;
using Xunit;

namespace RecordsInsideOut.Test._02_Record;

public class _02_InterfaceTest
{
    [Fact]
    public void _02_Work_With_Record_Inheritance()
    {
        var student = new InheritanceStudent("John", "Doe", 123456);
        student.Should().BeOfType<InheritanceStudent>();
    }
}