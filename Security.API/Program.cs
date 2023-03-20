using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Security.API.Configurations;
using Security.Application.Core;
using Security.Infrastructure.Persistence;
using Security.Infrastructure.Persistence.Configurations.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("SecurityDB")));

builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<ApiUser>>(builder.Configuration["JwtSettings:Issuer"]!)
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureJwtAuthentication(builder.Configuration);

builder.Services.AddAuthorizationBuilder()
  .AddPolicy("AdminOnly", policy =>
        policy
            .RequireRole("admin")
            .RequireAuthenticatedUser());

//adding services

builder.Services.AddScoped<ISecureGuardian, SecureGuardian>();


//adding Cors Policy**********************************************************************

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});








builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
