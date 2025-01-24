using E7.EasyResult;
using E7.EasyResult.Errors;
using ServicoProcessamento.Communication.Pesquisa.Requests;
using ServicoProcessamento.Communication.Responses;
using ServicoProcessamento.Domain.Pesquisa;
using ServicoProcessamento.Feature.Pesquisa.Extensions;

namespace ServicoProcessamento.Feature.Pesquisa.CreatePesquisa;

public sealed class CreatePesquisaUseCase(IPesquisaRepository pesquisaRepository) : ICreatePesquisaUseCase
{
    public async Task<Result<CreatePesquisaResponse>> ExecuteAsync(CreatePesquisaRequest request)
    {
        var validateResult = await ValidateAsync(request);

        if (validateResult.IsFailure) return validateResult.Error!;

        var pesquisa = new Domain.Pesquisa.Pesquisa(request.Codigo, request.InicioAsDateTimeOffset,
            request.FimAsDateTimeOffset);
        await pesquisaRepository.CreateAsync(pesquisa);

        return new CreatePesquisaResponse(pesquisa.Id, pesquisa.Codigo, pesquisa.Inicio, pesquisa.Fim);
    }

    private static async Task<Result> ValidateAsync(CreatePesquisaRequest request)
    {
        var validator = new CreatePesquisaValidator();
        var response = await validator.ValidateAsync(request);

        return response.IsValid.IsFalse()
            ? new InvalidFieldsError(response.Errors.Select(error => error.ErrorMessage).Distinct().ToList()!)
            : Result.Success();
    }
}