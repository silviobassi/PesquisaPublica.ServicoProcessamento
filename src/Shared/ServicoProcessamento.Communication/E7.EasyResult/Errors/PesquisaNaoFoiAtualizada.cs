using System.Net;

namespace ServicoProcessamento.Communication.E7.EasyResult.Errors;

public class PesquisaNaoFoiAtualizada() : AppError("A Pesquisa não foi atualizada", ErrorType.BusinessRule,
    nameof(PesquisaNaoFoiAtualizada))
{
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;

    public override List<string?> GetErrorsMessage() => [Message];
}