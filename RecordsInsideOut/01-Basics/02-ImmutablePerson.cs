namespace RecordsInsideOut._01_Basics;

public class ImmutablePerson
{
    public string FirstName { get; }
    public string LastName { get; }

    public ImmutablePerson(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}