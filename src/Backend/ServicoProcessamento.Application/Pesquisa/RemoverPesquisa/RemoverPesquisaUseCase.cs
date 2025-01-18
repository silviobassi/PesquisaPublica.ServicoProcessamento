using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.RemoverPesquisa;

public class RemoverPesquisaUseCase(IPesquisaRepository pesquisaRepository) : IRemoverPesquisaUseCase
{
    public async Task ExecuteAsync(string idPesquisa)
    {
        // Se a pesquisa já estiver ativa e com respostas, não deve ser possível excluí-la
        
        var deleteCount = await pesquisaRepository.RemoverPesquisaAsync(idPesquisa);
        
        if (deleteCount == 0) throw new ArgumentException("Pesquisa não encontrada");
    }
}