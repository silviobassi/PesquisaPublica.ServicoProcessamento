namespace ServicoProcessamento.Communication.Responses;

public record CreatePesquisaResponse(string Id, string Codigo, DateTimeOffset Inicio, DateTimeOffset Fim);