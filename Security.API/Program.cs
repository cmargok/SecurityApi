using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Security.API.Configurations;
using Security.Application.Models.Security;
using Security.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);


//var DbConnection = await SecretsManager.GetConnectionString(builder.Environment.IsDevelopment(),  builder.Configuration.GetConnectionString("Connection")!,
//    Environment.GetEnvironmentVariable("KeyVaultUrl")!.ToString(), builder.Configuration["ConnectionStringSecreto"]);

builder.Services.AddDbContext<IdentityDBContext>(
    options => options.UseSqlServer(Environment.GetEnvironmentVariable("SecutiryDb")
    //   ,bv => bv.MigrationsAssembly(typeof(IdentityDBContext).Assembly.FullName)
    ));

builder.Services.AddIdentityCore<ApiUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<ApiUser>>(builder.Configuration["JwtSettings:Issuer"]!)   
    .AddEntityFrameworkStores<IdentityDBContext>()
    .AddDefaultTokenProviders();

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




builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddRepositories();




builder.Services.AddControllers(
    options =>
    {
        options.Filters.Add<CustomValidationFilterAttribute>();
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });


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
