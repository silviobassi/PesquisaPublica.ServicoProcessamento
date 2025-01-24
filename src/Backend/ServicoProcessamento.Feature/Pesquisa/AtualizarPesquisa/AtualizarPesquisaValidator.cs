using FluentValidation;
using ServicoProcessamento.Communication.Pesquisa.Requests;
using ServicoProcessamento.Feature.Pesquisa.Extensions;

namespace ServicoProcessamento.Feature.Pesquisa.AtualizarPesquisa;

public class AtualizarPesquisaValidator : AbstractValidator<AtualizarPesquisaRequest>
{
    public AtualizarPesquisaValidator()
    {
        RuleFor(pesquisa => pesquisa.Id).NotEmpty().WithMessage("Id da pesquisa não pode ser vazio.");
        RuleFor(pesquisa => pesquisa.Codigo).NotEmpty().WithMessage("Código da pesquisa não pode ser vazio.");

        RuleFor(pesquisa => pesquisa.Inicio)!.ValidatorDataInicio();
        RuleFor(pesquisa => pesquisa.Fim)!.ValidatorDataFim();

        RuleFor(pesquisa => pesquisa.Fim)
            .NotEmpty().WithMessage("Data do fim da pesquisa não pode ser vazia.")
            .Matches(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$")
            .WithMessage("Data do fim deve estar no formato 'yyyy-MM-ddTHH:mm:ss'.");
    }
}