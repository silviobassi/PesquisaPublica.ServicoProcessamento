namespace ServicoProcessamento.Domain.Pesquisa.Entities;

public sealed class Alternativa(string id, string descricao)
{
    public string Id { get; private set; } = id;
    public string Descricao { get; private set; } = descricao;
    public List<string> RespondedorIds { get; private set; } = [];

    public void AdicionarRespondedor(string idRespondedor) => RespondedorIds.Add(idRespondedor);
    
    public void ObterId(string id) => Id = id;
}