using Validation.Api.Models;

namespace Validation.Api.Services.Validator3;

public class PersonsRequestRequestLastNameValidator : IPersonsRequestValidator
{
    public bool IsValid(PersonCreateRequest request) => !string.IsNullOrEmpty(request.LastName);

    public string ErrorMessage(PersonCreateRequest request) => $"{nameof(request.LastName)} is null or empty";
}