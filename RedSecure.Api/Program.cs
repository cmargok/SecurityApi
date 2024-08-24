using RedSecure.Api.Configurations.Middleware;
using RedSecure.Api.Configurations.Modules.Injection;
using RedSecure.Api.Configurations.Modules.Persistence;
using RedSecure.Api.Configurations.Modules.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationDependencies();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddSwaggerUI();



builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
