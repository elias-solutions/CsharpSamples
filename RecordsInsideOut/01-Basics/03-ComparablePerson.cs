namespace RecordsInsideOut._01_Basics
{
    public class ComparablePerson : IEquatable<ComparablePerson>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        // Expression Body constructed
        public ComparablePerson(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);

        public ComparablePerson() => (FirstName, LastName) = ("", "");


        public bool Equals(ComparablePerson? other)
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
            return Equals((ComparablePerson)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
