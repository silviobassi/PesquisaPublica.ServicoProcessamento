using ServicoProcessamento.Communication.E7.EasyResult;
using ServicoProcessamento.Communication.E7.EasyResult.Errors;
using ServicoProcessamento.Communication.Pesquisa.Requests;
using ServicoProcessamento.Communication.Pesquisa.Responses;
using ServicoProcessamento.Domain.Pesquisa.Factories;
using ServicoProcessamento.Domain.Pesquisa.Repositories;
using ServicoProcessamento.Feature.Pesquisa.Extensions;

namespace ServicoProcessamento.Feature.Pesquisa.CreatePesquisa;

public sealed class CreatePesquisaUseCase(IPesquisaRepository pesquisaRepository)
    : ICreatePesquisaUseCase
{
    public async Task<Result<CreatePesquisaResponse>> ExecuteAsync(CreatePesquisaRequest request)
    {
        var validateResult = await ValidateAsync(request);

        if (!validateResult.IsSuccess) return validateResult.Error!;

        var pesquisaEntity =
            PesquisaFactory.Criar(request.Codigo, request.InicioAsDateTimeOffset, request.FimAsDateTimeOffset);

        await pesquisaRepository.CreateAsync(pesquisaEntity);

        return new CreatePesquisaResponse(pesquisaEntity.Id!, pesquisaEntity.Codigo!, pesquisaEntity.Inicio,
            pesquisaEntity.Fim);
    }

    private static async Task<Result<bool>> ValidateAsync(CreatePesquisaRequest request)
    {
        var validator = new CreatePesquisaValidator();
        var response = await validator.ValidateAsync(request);

        return response.IsValid.IsFalse()
            ? new InvalidFieldsError(response.Errors.Select(error => error.ErrorMessage).Distinct().ToList()!)
            : Result<bool>.Success(true);
    }
}