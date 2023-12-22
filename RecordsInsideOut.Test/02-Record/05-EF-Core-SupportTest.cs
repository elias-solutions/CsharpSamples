using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RecordsInsideOut._02_Record;
using Xunit;

namespace RecordsInsideOut.Test._02_Record;

public class _05_EF_Core_SupportTest
{
    [Fact]
    public async Task Records_With_EFCore()
    {
        var factory = new PersonContextFactory();
        await using var context = factory.CreateDbContext(Array.Empty<string>());

        var person = new PersonEntity(0, "Charli", "Chaplin");
        context.Persons.Add(person);
        await context.SaveChangesAsync();

        person.Id.Should().NotBe(0);

        context.Entry(person).State = EntityState.Detached;
        person = person with { FirstName = "Charlie" };
        context.Persons.Update(person);
        await context.SaveChangesAsync();

        var dbPersons = await context.Persons.ToArrayAsync();
        dbPersons.Should().HaveCount(1);
        dbPersons.Should().ContainSingle(x => x.FirstName == "Charlie");
    }
}