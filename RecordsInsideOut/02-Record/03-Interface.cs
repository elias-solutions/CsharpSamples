namespace RecordsInsideOut._02_Record;

public interface IPerson
{
    string FirstName { get; }
    string LastName { get; }
}

public record PersonWithInterface(string FirstName, string LastName) : IPerson;

public record StudentWithInterface(string FirstName, string LastName, string StudentId) : IPerson;