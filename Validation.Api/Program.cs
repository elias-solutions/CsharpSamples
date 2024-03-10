using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Validation.Api;
using Validation.Api.Services;
using Validation.Api.Services.Validator2;
using Validation.Api.Services.Validator3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<PersonsService>();
builder.Services.AddSingleton<PersonsValidator>();
builder.Services.AddSingleton<IPersonsRequestValidator, PersonsRequestRequestFirstNameValidator>();
builder.Services.AddSingleton<IPersonsRequestValidator, PersonsRequestRequestLastNameValidator>();
builder.Services.AddSingleton<IPersonsRequestValidator, PersonsRequestRequestValidator>();
builder.Services.AddSingleton<PersonsRequestFullValidation>();

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;

});
builder.Services.AddSwaggerGen(options => options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
