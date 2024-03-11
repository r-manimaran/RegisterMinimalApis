using Carter;

namespace RegisterMinimalApis.Extensions;

public static class DIConfiguration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddEndpointsApiExplorer()
            .AddCarter()
            .AddSwaggerGen()
            .AddRequestTimeouts();
    }

    public static void RegisterMiddlewares(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapCarter();

        app.UseRequestTimeouts();
    }
}
