using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ServicoProcessamento.Domain.Pesquisa;
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
        services.AddSingleton<IMongoClient, MongoClient>(_ =>
        {
            var connectionMongoDbLocal = configuration.GetConnectionString("MongoDbLocal");
            return new MongoClient(connectionMongoDbLocal);
        });

        services.AddSingleton<IMongoContext, MongoContext>();
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