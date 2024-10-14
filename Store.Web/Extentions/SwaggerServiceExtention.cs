using Microsoft.OpenApi.Models;

namespace Store.Web.Extentions
{
    public static class  SwaggerServiceExtention
    {
        public static IServiceCollection AddSwaggerDocumention(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", 
                    new OpenApiInfo { 
                        Title = "Store Api" 
                        ,Version="v1",
                        Contact=new OpenApiContact
                        {
                            Name="Noran",
                            Email="Noranmedht63@gmailcom",
                            Url=new Uri("https://x.com/home")
                        }
                    });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header usin the Bearer scheme. Example: \"Authorization:{token}\""
                    ,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Id= "bearer",
                        Type=ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition("bearer", securityScheme);
                var securityRequirements = new OpenApiSecurityRequirement
                {
                    {
                        securityScheme,new[]{ "bearer" }
                    }
                };
                options.AddSecurityRequirement(securityRequirements);   
            });
            return services;
        }

    }
}
