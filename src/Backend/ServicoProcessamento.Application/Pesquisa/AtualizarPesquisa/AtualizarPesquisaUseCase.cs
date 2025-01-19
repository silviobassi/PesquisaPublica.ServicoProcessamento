using ServicoProcessamento.Application.Extensions;
using ServicoProcessamento.Communication.Errors;
using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;

public class AtualizarPesquisaUseCase(IPesquisaRepository pesquisaRepository) : IAtualizarPesquisaUseCase
{
    public async Task<Result> ExecuteAsync(AtualizarPesquisaRequest request)
    {
        var result = await ValidateAsync(request);
        
        if (result.Error is not null) return result.Error;

        var pesquisa = new Domain.Pesquisa.Entities.Pesquisa(request.Codigo, request.Inicio, request.Fim);

        pesquisa.ObterId(request.Id);

        var (matchedCount, modifiedCount) = await pesquisaRepository.AtualizarPesquisaAsync(pesquisa);

        if (matchedCount == 0) return new PesquisaNaoEncontradaError();

        if (modifiedCount == 0) return new NenhumaAlteracaoRealizadaError();

        return Result.Success();
    }

    private static async Task<Result> ValidateAsync(AtualizarPesquisaRequest request)
    {
        var validator = new AtualizarPesquisaValidator();
        var result = await validator.ValidateAsync(request);

        // Incluir dentro de Objeto
        return result.IsValid.IsFalse()
            ? new ValidacaoError(result.Errors.Select(error => error.ErrorMessage).Distinct().ToList())
            : Result.Success();
    }
}