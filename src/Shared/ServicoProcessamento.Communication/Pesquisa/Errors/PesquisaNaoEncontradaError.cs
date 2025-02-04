using System.Net;
using ServicoProcessamento.Communication.E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Pesquisa.Errors;

public class PesquisaNaoEncontradaError()
    : AppError("Pesquisa não encontrada", ErrorType.NotFoundRule, nameof(PesquisaNaoEncontradaError))
{
    public override List<string?> GetErrorsMessage() => [Message];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}