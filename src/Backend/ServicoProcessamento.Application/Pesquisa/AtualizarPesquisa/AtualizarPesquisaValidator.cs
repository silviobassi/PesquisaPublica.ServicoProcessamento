using FluentValidation;
using ServicoProcessamento.Communication.Requests;

namespace ServicoProcessamento.Application.Pesquisa.AtualizarPesquisa;

public class AtualizarPesquisaValidator : AbstractValidator<AtualizarPesquisaRequest>
{
    public AtualizarPesquisaValidator()
    {
        RuleFor(pesquisa => pesquisa.Id).NotEmpty().WithMessage("Id da pesquisa não pode ser vazio.");
        RuleFor(pesquisa => pesquisa.Codigo).NotEmpty().WithMessage("Código da pesquisa não pode ser vazio.");

        RuleFor(pesquisa => pesquisa.Inicio)
            .NotEmpty().WithMessage("Data do início da pesquisa não pode ser vazia.")
            .Matches(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$")
            .WithMessage("Data do início deve estar no formato 'yyyy-MM-ddTHH:mm:ss'.");

        RuleFor(pesquisa => pesquisa.Fim)
            .NotEmpty().WithMessage("Data do fim da pesquisa não pode ser vazia.")
            .Matches(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$")
            .WithMessage("Data do fim deve estar no formato 'yyyy-MM-ddTHH:mm:ss'.");
    }
}