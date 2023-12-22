using FluentAssertions;
using RecordsInsideOut._02_Record;
using Xunit;

namespace RecordsInsideOut.Test._02_Record
{
    public class _01_RecordPersonTest
    {
        [Fact]
        public void _01_Work_With_Person_Record_Deconstruction()
        {
            var person1 = new Person("Charlie", "Chaplin");

            // Deconstruction
            var (firstName, _) = person1;
            firstName.Should().Be("Charlie");
        }

        [Fact]
        public void _02_Work_With_Person_Record_Cloning()
        {
            var person1 = new Person("Charli", "Chaplin");

            // Cloning without changes
            var person2 = person1 with { };
            person1.Should().Be(person2);
            person1.Should().NotBeSameAs(person2);

            // Cloning without changes
            var person3 = person1 with { FirstName = "Charlie" };
            person1.Should().NotBe(person3);
            person1.Should().NotBeSameAs(person3);
        }

        [Fact]
        public void _03_Work_With_Person_Record_Lists() 
        {
            // Creating and initializing collections
            var person1 = new Person("Charlie", "Chaplin");
            var persons = new[]
            {
                person1,
                person1 with { FirstName = "Mildred" },
                person1 with { FirstName = "Lita" },
                person1 with { FirstName = "Pauletta" },
                person1 with { FirstName = "Oona" }
            };

            persons.Should().BeEquivalentTo(GetExpectedPersons());
        }

        private static IEnumerable<Person> GetExpectedPersons()
        {
            yield return new Person("Charlie", "Chaplin");
            yield return new Person("Mildred", "Chaplin");
            yield return new Person("Pauletta", "Chaplin");
            yield return new Person("Lita", "Chaplin");
            yield return new Person("Oona", "Chaplin");
        }
    }
}
