using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;

public class AtualizarPesquisaUseCase(IPesquisaRepository pesquisaRepository) : IAtualizarPesquisaUseCase
{
    public async Task ExecuteAsync(AtualizarPesquisaRequest request)
    {
        var pesquisa = await pesquisaRepository.ObterPesquisaPorIdAsync(request.Id);

        if (pesquisa is null) throw new ArgumentException("Pesquisa não encontrada");

        pesquisa = new Domain.Pesquisa.Entities.Pesquisa
        {
            Id = request.Id,
            Codigo = request.Codigo,
            Inicio = request.Inicio,
            Fim = request.Fim
        };

        await pesquisaRepository.AtualizarPesquisaAsync(pesquisa);
    }
}