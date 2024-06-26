using Stock.Management.Api.Configuration;
using Stock.Management.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrelHttpsConfiguration();
if (builder.Environment.IsProduction())
{
    var portVar = Environment.GetEnvironmentVariable("PORT");
    if (portVar is { Length: > 0 } && int.TryParse(portVar, out var port))
    {
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(port);
        });
    }
}
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfig();
builder.Configuration.AddJsonFile($"appsettings.json", false, false);
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddMappings();

builder.Services.ResolveDependecies(builder.Configuration);

var app = builder.Build();

//if (!app.Environment.IsEnvironment("producao"))
//{
    app.UseSwagger(c =>
    {
        c.SerializeAsV2 = true;

        c.PreSerializeFilters.Add((swagger, request) =>
        {
            swagger.Servers = [new() { Url = app.Configuration["Swagger:basePath"] }];
        });
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(app.Configuration["Swagger:endpoint"], "v1");
    });


//}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors("AllowAll");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
