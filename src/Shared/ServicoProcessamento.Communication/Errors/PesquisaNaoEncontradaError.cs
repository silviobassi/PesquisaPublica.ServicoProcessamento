using System.Net;

namespace ServicoProcessamento.Communication.Errors;

public class PesquisaNaoEncontradaError()
    : AppError("Pesquisa não encontrada", ErrorType.NotFoundRule, nameof(PesquisaNaoEncontradaError))
{
    public override List<string?> GetErrorsMessage() => [Detail];
    
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}