using Validation.Api.Controllers;

namespace Validation.Api.Services.Validator3;

public class PersonsRequestRequestFirstNameValidator : IPersonsRequestValidator
{
    public bool IsValid(PersonCreateRequest request) => !string.IsNullOrEmpty(request.FirstName);

    public string ErrorMessage(PersonCreateRequest request) => $"{nameof(request.FirstName)} is null or empty";
}