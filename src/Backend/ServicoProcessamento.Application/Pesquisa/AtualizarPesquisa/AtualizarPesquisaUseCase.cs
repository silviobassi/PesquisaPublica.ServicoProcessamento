using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;

public class AtualizarPesquisaUseCase(IPesquisaRepository pesquisaRepository) : IAtualizarPesquisaUseCase
{
    public async Task ExecuteAsync(AtualizarPesquisaRequest request)
    {
        var pesquisa = new Domain.Pesquisa.Entities.Pesquisa
        {
            Id = request.Id,
            Codigo = request.Codigo,
            Inicio = request.Inicio,
            Fim = request.Fim
        };

        var (matchedCount, modifiedCount) = await pesquisaRepository.AtualizarPesquisaAsync(pesquisa);

        if (matchedCount == 0) throw new ArgumentException("Pesquisa não encontrada");

        if (modifiedCount == 0) throw new ArgumentException("Nenhuma alteração realizada");
    }
}