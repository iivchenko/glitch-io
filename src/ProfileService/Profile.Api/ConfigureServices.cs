using Microsoft.OpenApi.Models;

namespace Profile.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddCors(optons => optons.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

        services.AddHttpContextAccessor();

        services.AddHealthChecks(); // TODO: add proper health check to DB as well

        services.AddControllers();
        // TODO: Finish later
        //services.AddControllers(options =>
        //     options.Filters.Add<ApiExceptionFilterAttribute>())
        //        .AddFluentValidation(x => x.AutomaticValidationEnabled = false);
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "User Profile API", Version = "v1" });
        });

        // TODO: Finsih later, maybe not necessary
        // Customise default API behaviour
        //services.Configure<ApiBehaviorOptions>(options =>
        //    options.SuppressModelStateInvalidFilter = true);

        return services;
    }
}

