using Validation.Api.Models;

namespace Validation.Api.Services.Validator3;

public interface IPersonsRequestValidator
{
    bool IsValid(PersonCreateRequest request);

    string ErrorMessage(PersonCreateRequest request);
}