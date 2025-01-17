using Microsoft.Extensions.DependencyInjection;
using ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;
using ServicoProcessamento.Application.Pesquisa.CreatePesquisa;
using ServicoProcessamento.Application.Pesquisa.ObterPesquisaPorId;

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
        services.AddScoped<IObterPesquisaPorIdUseCase, ObterPesquisaPorIdUseCase>();
        services.AddScoped<IAtualizarPesquisaUseCase, AtualizarPesquisaUseCase>();
    }
}