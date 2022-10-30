using Profile.Api;
using Profile.Application;
using Profile.Infra;
using Profile.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "User Profile API V1"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // TODO: Implement develop seed later
    //app.UseDeveloperExceptionPage();
    //app.UseMigrationsEndPoint();

    // Initialise and seed database
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<DevelopDbSeeder>();
        await initialiser.SeedAsync();
    }
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

// TODO: Add authorization later
//app.UseAuthorization();

app.MapControllers();

app.Run();
