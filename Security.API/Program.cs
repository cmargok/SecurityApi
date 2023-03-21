using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Security.API.Configurations;
using Security.Application.Models.Security;
using Security.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var DbConnection = await SecretsManager.GetConnectionString(builder.Environment.IsDevelopment(), builder.Configuration);

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(DbConnection));



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




//adding Cors Policy**********************************************************************

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
});




builder.Services.RegisterServices();



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
