namespace RecordsInsideOut._02_Record;

public record InheritancePerson(string FirstName, string LastName);

public record InheritanceStudent(string FirstName, string LastName, string StudentId) : InheritancePerson(FirstName, LastName);