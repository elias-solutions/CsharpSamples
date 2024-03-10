using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Validation.Api.Models;
using Validation.Api.Services;

namespace Validation.Api.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/persons")]
public class PersonsController : ControllerBase
{
    private readonly List<Person> _persons;

    public PersonsController(PersonsService personsService) => _persons = personsService.GetPersons().ToList();

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
        if (request == null)
        {
            return BadRequest($"{nameof(request)} is null");
        }

        if (string.IsNullOrEmpty(request.FirstName))
        {
            return BadRequest($"{nameof(request.FirstName)} is null or empty");
        }

        if (string.IsNullOrEmpty(request.LastName))
        {
            return BadRequest($"{nameof(request.LastName)} is null or empty");
        }

        var person = new Person(Guid.NewGuid(), request.FirstName, request.LastName);
        _persons.Add(person);
        return Ok(person);
    }
}