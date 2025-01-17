namespace ServicoProcessamento.Communication.Responses;

public record ObterPesquisaResponse(string Id, string Codigo, DateTime Inicio, DateTime Fim);