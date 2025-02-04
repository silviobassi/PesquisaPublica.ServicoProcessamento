using ServicoProcessamento.Api.Middlewares;
using ServicoProcessamento.Feature;
using ServicoProcessamento.Infrastructure;
using ServicoProcessamento.Infrastructure.Data.Migrations;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.MapControllers();

MongoDbConfigurator.Configure();

await app.RunAsync();

// Configure the app to use MongoDb in memory if the configuration is set to use it
// Release memory after the application is closed
app.DisposeMongoDbInMemory(builder.Configuration);