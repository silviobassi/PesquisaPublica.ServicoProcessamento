namespace ServicoProcessamento.Communication.Responses;

public record ObterPesquisaResponse(string Id, string Codigo, DateTimeOffset Inicio, DateTimeOffset Fim, bool Ativa);