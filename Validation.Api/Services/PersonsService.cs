using Validation.Api.Models;

namespace Validation.Api.Services;

public class PersonsService
{
    public List<Person> GetPersons() => CreatePersons().ToList();

    private IEnumerable<Person> CreatePersons()
    {
        yield return new Person(Guid.NewGuid(), "Michael", "Jackson");
        yield return new Person(Guid.NewGuid(), "Michael", "Jordan");
        yield return new Person(Guid.NewGuid(), "Michael", "Schumacher");
    }
}