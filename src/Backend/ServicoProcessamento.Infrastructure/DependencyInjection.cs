using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mongo2Go;
using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa.Repositories;
using ServicoProcessamento.Infrastructure.Consumers;
using ServicoProcessamento.Infrastructure.Data.Context;
using ServicoProcessamento.Infrastructure.Data.Repositories;

namespace ServicoProcessamento.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddMongoDb(services, configuration);
        AddRepositories(services);
        AddServiceBus(services, configuration);
        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IPesquisaRepository, PesquisaRepository>();
    }

    private static void AddMongoDb(IServiceCollection services, IConfiguration configuration)
    {
        var useInMemory = configuration.GetValue<bool>("MongoDB:UseInMemory");

        if (useInMemory)
        {
            var runner = MongoDbRunner.Start();
            var mongoClient = new MongoClient(runner.ConnectionString);
            var database = mongoClient.GetDatabase("InMemoryDb");
            
            services.AddSingleton<IMongoClient>(mongoClient);
            services.AddSingleton(database);
            services.AddSingleton(runner);
        }
        else
        {
            services.AddSingleton<IMongoClient, MongoClient>(_ =>
            {
                var connectionMongoDbLocal = configuration.GetConnectionString("MongoDbLocal");
                return new MongoClient(connectionMongoDbLocal);
            });
        }


        services.AddSingleton<IMongoContext, MongoContext>();
    }

    public static void DisposeMongoDbInMemory(this WebApplication app, IConfiguration configuration)
    {
        var useInMemory = configuration.GetValue<bool>("MongoDB:UseInMemory");

        if (!useInMemory)
            return;

        var runner = app.Services.GetService<MongoDbRunner>();
        app.Lifetime.ApplicationStopping.Register(() => runner?.Dispose());
    }


    private static void AddServiceBus(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<PesquisaRespondidaEventConsumer>(typeof(PesquisaRespondidaDefinition));
            busConfigurator.AddConsumer<DashboardFaultConsumer>();

            busConfigurator.UsingAzureServiceBus((context, configurator) =>
            {
                var connection = configuration.GetValue<string>("ConnectionStrings:AzureServiceBus")!;
                configurator.Host(new Uri(connection));
                configurator.ConfigureEndpoints(context);
            });
        });
    }
}