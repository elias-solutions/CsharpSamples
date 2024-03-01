using Validation.Api.Controllers;

namespace Validation.Api.Services.Validator2;

public class PersonsValidator
{
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
        if (request == null)
        {
            yield return $"{nameof(request)} is null";
        }

        if (string.IsNullOrEmpty(request.FirstName))
        {
            yield return $"{nameof(request.FirstName)} is null or empty";
        }

        if (string.IsNullOrEmpty(request.LastName))
        {
            yield return $"{nameof(request.LastName)} is null or empty";
        }
    }
}