using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.CreatePesquisa;

public sealed  class CreatePesquisaUseCase(IPesquisaRepository repository)
{
    public async Task ExecuteAsync(CreatePequisaRequest request)
    {
        var pesquisa = new Domain.Pesquisa.Entities.Pesquisa
        {
            Codigo = request.Codigo,
            Inicio = request.Inicio,
            Fim = request.Fim
        };

        await repository.Create(pesquisa);
    }
}