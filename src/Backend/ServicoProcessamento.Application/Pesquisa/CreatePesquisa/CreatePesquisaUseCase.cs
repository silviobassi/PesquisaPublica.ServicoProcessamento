using ServicoProcessamento.Communication.Errors;
using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Communication.Responses;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.CreatePesquisa;

public class CreatePesquisaUseCase(IPesquisaRepository pesquisaRepository) : ICreatePesquisaUseCase
{
    public async Task<Result<CreatePesquisaResponse>> ExecuteAsync(CreatePesquisaRequest request)
    {
        var pesquisa = new Domain.Pesquisa.Entities.Pesquisa(request.Codigo, request.Inicio, request.Fim);
        await pesquisaRepository.CreateAsync(pesquisa);
        return new CreatePesquisaResponse(pesquisa.Id, pesquisa.Codigo, pesquisa.Inicio, pesquisa.Fim);
    }
}