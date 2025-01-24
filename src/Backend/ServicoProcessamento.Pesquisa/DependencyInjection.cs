using Microsoft.Extensions.DependencyInjection;
using ServicoProcessamento.Pesquisa.AtualizarPesquisa;
using ServicoProcessamento.Pesquisa.CreatePesquisa;
using ServicoProcessamento.Pesquisa.ObterPesquisaPorId;
using ServicoProcessamento.Pesquisa.RemoverPesquisa;

namespace ServicoProcessamento.Pesquisa;

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
        services.AddScoped<IRemoverPesquisaUseCase, RemoverPesquisaUseCase>();
    }
}