using Microsoft.Extensions.DependencyInjection;
using ServicoProcessamento.Feature.Pesquisa.AtualizarPesquisa;
using ServicoProcessamento.Feature.Pesquisa.CreatePesquisa;
using ServicoProcessamento.Feature.Pesquisa.ObterPesquisaPorId;
using ServicoProcessamento.Feature.Pesquisa.RemoverPesquisa;

namespace ServicoProcessamento.Feature;

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