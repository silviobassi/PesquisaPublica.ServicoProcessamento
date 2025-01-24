using System.Net;
using E7.EasyResult.Errors;

namespace ServicoProcessamento.Communication.Pesquisa.Errors;

public class PesquisaNaoEncontradaError()
    : AppError("Pesquisa não encontrada", ErrorType.NotFoundRule, nameof(PesquisaNaoEncontradaError))
{
    public override List<string?> GetErrorsMessage() => [Detail];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}