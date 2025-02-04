namespace ServicoProcessamento.Communication.Pesquisa.Responses;

public record CreatePesquisaResponse(string Id, string Codigo, DateTimeOffset? Inicio, DateTimeOffset? Fim);