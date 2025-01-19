using ServicoProcessamento.Application.Extensions;
using ServicoProcessamento.Communication.Errors;
using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;

public class AtualizarPesquisaUseCase(IPesquisaRepository pesquisaRepository) : IAtualizarPesquisaUseCase
{
    public async Task<Result> ExecuteAsync(AtualizarPesquisaRequest request)
    {
        await ValidateAsync(request);

        var pesquisa = new Domain.Pesquisa.Entities.Pesquisa(request.Codigo, request.Inicio, request.Fim);

        pesquisa.ObterId(request.Id);

        var (matchedCount, modifiedCount) = await pesquisaRepository.AtualizarPesquisaAsync(pesquisa);

        if (matchedCount == 0) return new PesquisaNaoEncontradaError();

        if (modifiedCount == 0) return new NenhumaAlteracaoRealizadaError();

        return Result.Success();
    }

    private static async Task<List<string>> ValidateAsync(AtualizarPesquisaRequest request)
    {
        var validator = new AtualizarPesquisaValidator();
        var result = await validator.ValidateAsync(request);

        // Incluir dentro de Objeto
        return result.IsValid.IsFalse() ? result.Errors.Select(error => error.ErrorMessage).Distinct().ToList() : [];
    }
}