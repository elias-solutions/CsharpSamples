namespace RecordsInsideOut._01_Basics
{
    public class CloneablePerson : IEquatable<CloneablePerson>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public CloneablePerson(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);

        public CloneablePerson() => (FirstName, LastName) = ("", "");


        public bool Equals(CloneablePerson? other)
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
            return Equals((CloneablePerson)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }

        public CloneablePerson Clone() => new(FirstName, LastName);
        public CloneablePerson CloneLastName(string firstName) => new(firstName, LastName);
        public CloneablePerson CloneFirstName(string lastName) => new(FirstName, lastName);
    }
}
