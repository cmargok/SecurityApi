namespace Security.API.Configurations
{
    public static class JwtAuthentication
    {

        public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(JwtOptions =>
            //{
            //    JwtOptions.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        ValidateAudience = true,
            //        ValidateIssuer = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey!)),
            //    };
            //});

        }
    }
}
