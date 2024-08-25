using Security.API.Configurations;

var builder = WebApplication.CreateBuilder(args);


//var DbConnection = await SecretsManager.GetConnectionString(builder.Environment.IsDevelopment(),  builder.Configuration.GetConnectionString("Connection")!,
//    Environment.GetEnvironmentVariable("KeyVaultUrl")!.ToString(), builder.Configuration["ConnectionStringSecreto"]);



builder.Services.ConfigureJwtAuthentication(builder.Configuration);

builder.Services.AddAuthorizationBuilder()
  .AddPolicy("AdminOnly", policy =>
        policy
            .RequireRole("admin")
            .RequireAuthenticatedUser());

//adding services

    


//adding Cors Policy**********************************************************************

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});



builder.Services.AddInfrastructureServices(builder.Configuration);







// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
