using RedSecure.Api.Configurations.Filters;
using RedSecure.Api.Configurations.Middleware;
using RedSecure.Api.Configurations.Modules.Authentication;
using RedSecure.Api.Configurations.Modules.Correlation;
using RedSecure.Api.Configurations.Modules.Events;
using RedSecure.Api.Configurations.Modules.Injection;
using RedSecure.Api.Configurations.Modules.Persistence;
using RedSecure.Api.Configurations.Modules.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDomainDependencies();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationDependencies();
builder.Services.AddJwt();
builder.Services.AddCorrelationId();
builder.Services.AddNotificationsApiEvent();
builder.Services.AddSwaggerUI();
builder.Services.AddControllers(
    options => options.Filters.Add<CustomValidationFilterAttribute>())
    .ConfigureApiBehaviorOptions(
    options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<CorrelationIdMiddleware>();

app.Run();
