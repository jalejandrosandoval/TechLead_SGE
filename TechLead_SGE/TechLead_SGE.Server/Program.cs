using TechLead_SGE.Server.Utilities.Classes.Swagger.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var config = builder.Configuration;

// SWAGGER CONFIG
builder.Services.ConfigureSwaggerApi(config);

var app = builder.Build();

// SWAGGER CONFIG UI
builder.Services.ConfigureSwaggerApiUI(config, app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();