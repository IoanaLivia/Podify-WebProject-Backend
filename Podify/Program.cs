using Microsoft.AspNetCore.Identity;
using Podify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method

var app = builder.Build();

startup.Configure(app, builder.Environment);//, seed); // calling Configure method


app.Run();
