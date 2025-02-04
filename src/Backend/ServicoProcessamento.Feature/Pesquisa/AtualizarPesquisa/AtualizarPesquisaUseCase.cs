using ServicoProcessamento.Communication.E7.EasyResult;
using ServicoProcessamento.Communication.E7.EasyResult.Errors;
using ServicoProcessamento.Communication.Pesquisa.Errors;
using ServicoProcessamento.Communication.Pesquisa.Requests;
using ServicoProcessamento.Domain.Pesquisa.Entities;
using ServicoProcessamento.Domain.Pesquisa.Factories;
using ServicoProcessamento.Domain.Pesquisa.Repositories;
using ServicoProcessamento.Feature.Pesquisa.Extensions;

namespace ServicoProcessamento.Feature.Pesquisa.AtualizarPesquisa;

public class AtualizarPesquisaUseCase(IPesquisaRepository pesquisaRepository) : IAtualizarPesquisaUseCase
{
    public async Task<Result> ExecuteAsync(AtualizarPesquisaRequest request)
    {
        var validateAsync = await ValidateAsync(request);

        return validateAsync.MapFailure(x => x)
            .Map(_ => pesquisaRepository.ObterPesquisaPorIdAsync(request.Id))
            .Bind(VerificarSePesquisaExiste)
            .Bind(VerificarSePesquisaEstaSendoRespondida)
            .Map(_ => PesquisaFactory.Atualizar(request.Id, request.Codigo, request.InicioAsDateTimeOffset,
                request.FimAsDateTimeOffset))
            .Map(pesquisaRepository.AtualizarPesquisaAsync)
            .Bind(VerificarSePesquisaFoiAtualizada);
    }
    
    private static async Task<Result<bool>> ValidateAsync(AtualizarPesquisaRequest request)
    {
        var validator = new AtualizarPesquisaValidator();
        var response = await validator.ValidateAsync(request);

        return response.IsValid.IsFalse()
            ? new InvalidFieldsError(response.Errors.Select(error => error.ErrorMessage).Distinct().ToList()!)
            : Result<bool>.Success(true);
    }

    private static Result<PesquisaEntity?> VerificarSePesquisaExiste(PesquisaEntity? pesquisa)
        => pesquisa is null ? new PesquisaNaoEncontradaError() : pesquisa;

    private static Result<PesquisaEntity?> VerificarSePesquisaEstaSendoRespondida(
        PesquisaEntity? pesquisa)
        => pesquisa!.Ativa && pesquisa.EstaSendoRespondida ? new PesquisaEstaSendoRespondidaError() : pesquisa;

    private static Result<bool> VerificarSePesquisaFoiAtualizada(long modifiedCount)
        => modifiedCount == 0 ? new PesquisaNaoFoiAtualizada() : Result<bool>.Success(true);
}