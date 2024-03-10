using Validation.Api.Models;

namespace Validation.Api.Services.Validator3;

public class PersonsRequestFullValidation
{
    private readonly IEnumerable<IPersonsRequestValidator> _personsRequestValidators;

    public PersonsRequestFullValidation(IEnumerable<IPersonsRequestValidator> personsRequestValidators)
    {
        _personsRequestValidators = personsRequestValidators;
    }

    public void ThrowIfInvalid(PersonCreateRequest request)
    {
        var result = Validate(request).ToList();
        if (result.Any())
        {
            throw new ArgumentException(string.Join(", ", result));
        }
    }

    public IEnumerable<string> Validate(PersonCreateRequest request)
    {
        foreach (var validator in _personsRequestValidators)
        {
            if (validator.IsValid(request))
            {
                yield return validator.ErrorMessage(request);
            }
        }
    }
}