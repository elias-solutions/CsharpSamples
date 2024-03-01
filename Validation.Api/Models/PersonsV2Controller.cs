using Microsoft.AspNetCore.Mvc;
using Validation.Api.Controllers;
using Validation.Api.Services;
using Validation.Api.Services.Validator2;

namespace Validation.Api.Models;

[Route("api/v2/persons")]
public class PersonsV2Controller : ControllerBase
{
    private readonly PersonsValidator _personsValidator;
    private readonly List<Person> _persons;

    public PersonsV2Controller(PersonsService personsService, PersonsValidator personsValidator)
    {
        _personsValidator = personsValidator;
        _persons = personsService.GetPersons().ToList();
    }

    [HttpGet]
    public IActionResult Get() => Ok(_persons.ToList());

    [HttpGet("{personId}")]
    public IActionResult Get(Guid personId)
    {
        if (personId == Guid.Empty)
        {
            return BadRequest("No personId found.");
        }

        if (_persons.All(x => x.Id != personId))
        {
            return BadRequest($"No person with given personId '{personId}' found.");
        }

        var person = _persons.Single(x => x.Id == personId);
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Create(PersonCreateRequest request)
    {
        _personsValidator.ThrowIfInvalid(request);
        var person = new Person(Guid.NewGuid(), request.FirstName, request.LastName);
        _persons.Add(person);
        return Ok(person);
    }
}