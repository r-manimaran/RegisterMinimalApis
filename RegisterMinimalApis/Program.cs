using Microsoft.AspNetCore.Http.HttpResults;
using RegisterMinimalApis;
using RegisterMinimalApis.Endpoints;
using RegisterMinimalApis.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

//app.RegisterUserEndpoints(); //Now we are using Carter Module instead of extension methods

app.RegisterWeatherForecastEndpoints();

app.Run();


