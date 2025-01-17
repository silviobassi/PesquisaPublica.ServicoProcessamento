namespace ServicoProcessamento.Communication.Requests;

public record CreatePesquisaRequest(string Codigo, DateTime Inicio, DateTime Fim);