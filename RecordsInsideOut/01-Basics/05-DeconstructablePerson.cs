namespace RecordsInsideOut._01_Basics;

public class DeconstructablePerson : IEquatable<DeconstructablePerson>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    // Expression Body constructed
    public DeconstructablePerson(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);

    public DeconstructablePerson() => (FirstName, LastName) = ("", "");


    public bool Equals(DeconstructablePerson? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return FirstName == other.FirstName && LastName == other.LastName;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DeconstructablePerson)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName);
    }

    public DeconstructablePerson Clone() => new(FirstName, LastName);
    public DeconstructablePerson CloneLastName(string firstName) => new(firstName, LastName);
    public DeconstructablePerson CloneFirstName(string lastName) => new(FirstName, lastName);
    public void Deconstruct(out string firstName, out string lastName) => (firstName, lastName) = (FirstName, LastName);
}