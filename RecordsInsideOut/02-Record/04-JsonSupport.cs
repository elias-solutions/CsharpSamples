using System.Text.Json.Serialization;

namespace RecordsInsideOut._02_Record;
public record PersonWithJsonSupport(
    [property: JsonPropertyName("Givenname")] string FirstName,
    [property: JsonPropertyName("Surename")] string LastName);