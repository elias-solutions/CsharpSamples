using System.Text.Json;
using FluentAssertions;
using RecordsInsideOut._02_Record;
using Xunit;

namespace RecordsInsideOut.Test._02_Record;

public class _04_JsonSupportTests
{
    [Fact]
    public void _04_Work_With_Record_JsonSupport()
    {
        var persons = new PersonWithJsonSupport[]
        {
            new("Charlie", "Chaplin"),
            new("Oona", "Chaplin")
        };

        var jsonStringPersons = JsonSerializer.Serialize(persons);
        jsonStringPersons.Should().Contain("Givenname");
        jsonStringPersons.Should().Contain("Surename");

        var deserializedPersons = JsonSerializer.Deserialize<PersonWithJsonSupport[]>(jsonStringPersons);
        deserializedPersons.Should().BeEquivalentTo(persons);
    }
}