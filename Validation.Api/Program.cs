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
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
