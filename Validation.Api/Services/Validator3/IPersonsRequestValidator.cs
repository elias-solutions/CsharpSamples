using Validation.Api.Controllers;

namespace Validation.Api.Services.Validator3;

public interface IPersonsRequestValidator
{
    bool IsValid(PersonCreateRequest request);

    string ErrorMessage(PersonCreateRequest request);
}