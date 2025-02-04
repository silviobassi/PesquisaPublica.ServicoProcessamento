using Moq;
using ServicoProcessamento.Communication.Pesquisa.Requests;
using ServicoProcessamento.Domain.Pesquisa.Entities;
using ServicoProcessamento.Domain.Pesquisa.Repositories;

namespace CommonTestUtilities.Repositories;

public class PesquisaRepositoryBuilder
{
    private readonly Mock<IPesquisaRepository> _repository = new();

    public IPesquisaRepository Build() => _repository.Object;

    public PesquisaRepositoryBuilder ObterPesquisaPorIdAsync(PesquisaEntity pesquisa, AtualizarPesquisaRequest request)
    {
        _repository.Setup(repository => repository.ObterPesquisaPorIdAsync(request.Id))
            .ReturnsAsync((string id) => id == pesquisa.Id ? pesquisa : null);
        return this;
    }

    public PesquisaRepositoryBuilder AtualizarPesquisaAsync()
    {
        _repository.Setup(repository => repository.AtualizarPesquisaAsync(It.IsAny<PesquisaEntity>()))
            .ReturnsAsync(1);
        return this;
    }
}