using E7.EasyResult;
using E7.EasyResult.Errors;
using FluentValidation.Results;
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

        if (result.IsFailure) return Result.Failure(result.Error);

        var pesquisa = new Domain.Pesquisa.Entities.Pesquisa(request.Codigo, request.InicioAsDateTimeOffset,
            request.FimAsDateTimeOffset);

        pesquisa.ObterId(request.Id);

        pesquisa = await pesquisaRepository.AtualizarPesquisaAsync(pesquisa);

        return pesquisa is null
            ? new PesquisaNaoEncontradaError()
            : Result.Success();
    }

    private static async Task<Result> ValidateAsync(AtualizarPesquisaRequest request)
    {
        var validator = new AtualizarPesquisaValidator();
        var response = await validator.ValidateAsync(request);

        return response.IsValid.IsFalse()
            ? new InvalidFieldsError(response.Errors.Select(error => error.ErrorMessage).Distinct().ToList()!)
            : Result.Success();
    }
}