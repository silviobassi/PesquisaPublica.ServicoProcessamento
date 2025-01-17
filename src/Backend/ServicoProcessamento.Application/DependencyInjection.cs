using Microsoft.Extensions.DependencyInjection;
using ServicoProcessamento.Application.Pesquisa.CreatePesquisa;

namespace ServicoProcessamento.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        return services;
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreatePesquisaUseCase, CreatePesquisaUseCase>();
    }
}