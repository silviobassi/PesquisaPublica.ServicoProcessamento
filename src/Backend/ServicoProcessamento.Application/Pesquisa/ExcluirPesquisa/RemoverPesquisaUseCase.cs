using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace ServicoProcessamento.Application.Pesquisa.ExcluirPesquisa;

public class RemoverPesquisaUseCase(IPesquisaRepository pesquisaRepository) : IRemoverPesquisaUseCase
{
    public async Task ExecuteAsync(string idPesquisa)
    {
        // Se a pesquisa já estiver ativa e com respostas, não deve ser possível excluí-la
        
        var pesquisa = await pesquisaRepository.ObterPesquisaPorIdAsync(idPesquisa);
        
        if(pesquisa is null) throw new ArgumentException("Pesquisa não encontrada");
        
        await pesquisaRepository.RemoverPesquisaAsync(idPesquisa);
    }
}