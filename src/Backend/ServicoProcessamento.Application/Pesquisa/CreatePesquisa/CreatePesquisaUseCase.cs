using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Communication.Responses;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.CreatePesquisa;

public class CreatePesquisaUseCase(IPesquisaRepository pesquisaRepository) : ICreatePesquisaUseCase
{
    public async Task<CreatePesquisaResponse> ExecuteAsync(CreatePesquisaRequest request)
    {
        var pesquisa = new Domain.Pesquisa.Entities.Pesquisa
            { Codigo = request.Codigo, Inicio = request.Inicio, Fim = request.Fim };
        await pesquisaRepository.CreateAsync(pesquisa);
        return new CreatePesquisaResponse(pesquisa.Codigo, pesquisa.Inicio, pesquisa.Fim);
    }
}