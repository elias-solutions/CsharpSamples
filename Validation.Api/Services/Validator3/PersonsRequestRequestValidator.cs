﻿using Validation.Api.Models;

namespace Validation.Api.Services.Validator3;

public class PersonsRequestRequestValidator : IPersonsRequestValidator
{
    public bool IsValid(PersonCreateRequest request) => !string.IsNullOrEmpty(request.FirstName);

    public string ErrorMessage(PersonCreateRequest request) => $"{nameof(request.FirstName)} is null or empty";
}