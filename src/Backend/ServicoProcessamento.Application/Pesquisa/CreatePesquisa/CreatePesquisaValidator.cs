using FluentValidation;
using ServicoProcessamento.Communication.Requests;

namespace ServicoProcessamento.Application.Pesquisa.CreatePesquisa;

public class CreatePesquisaValidator : AbstractValidator<CreatePesquisaRequest>
{
    public CreatePesquisaValidator()
    {
        RuleFor(pesquisa => pesquisa.Codigo).NotEmpty().WithMessage("Código da pesquisa não pode ser vazio.");
        RuleFor(pesquisa => pesquisa.Inicio).NotEmpty()
            .WithMessage("Data de início da pesquisa não pode ser vazia.")
            .Matches(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$")
            .WithMessage("Data de início deve estar no formato 'yyyy-MM-ddTHH:mm:ss'.");
        RuleFor(pesquisa => pesquisa.Fim).NotEmpty().WithMessage("Data de fim da pesquisa não pode ser vazia.")
            .Matches(@"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$")
            .WithMessage("Data de início deve estar no formato 'yyyy-MM-ddTHH:mm:ss'.");
    }
}