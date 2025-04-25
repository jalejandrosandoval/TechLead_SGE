using TechLead_SGE.Server.BL.Classes.Mapper;
using TechLead_SGE.Server.Data.DBContext.Common;
using TechLead_SGE.Server.Utilities.Classes.Mapper.Common;
using TechLead_SGE.Server.Utilities.Classes.Swagger.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var config = builder.Configuration;

// EF DBCONTEXT CONFIG IN TIME EXEC
builder.Services.ConfigureDbContextApi(config);

// AUTOMAPPER CONFIG
builder.Services.ConfigureMapper(typeof(AutoMapperSettings));

// SWAGGER CONFIG
builder.Services.ConfigureSwaggerApi(config);

var app = builder.Build();

// SWAGGER CONFIG UI
builder.Services.ConfigureSwaggerApiUI(config, app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();