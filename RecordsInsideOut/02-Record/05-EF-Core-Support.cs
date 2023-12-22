using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecordsInsideOut._02_Record;

public record Entity(int Id);
public record PersonEntity(int Id, string FirstName, string LastName) : Entity(Id);

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    // A record is just a special form of a class, so we
    // can use it with Entity Framework.
    public DbSet<PersonEntity> Persons => Set<PersonEntity>();
}

public class PersonContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args) =>
        new(new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase("Persons")
            .Options);
}