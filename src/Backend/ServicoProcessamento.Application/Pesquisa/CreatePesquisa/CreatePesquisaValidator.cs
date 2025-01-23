using FluentValidation;
using ServicoProcessamento.Communication.Requests;

namespace ServicoProcessamento.Application.Pesquisa.CreatePesquisa;

public class CreatePesquisaValidator : AbstractValidator<CreatePesquisaRequest>
{
    public CreatePesquisaValidator()
    {
        RuleFor(pesquisa => pesquisa.Codigo).NotEmpty().WithMessage("Código da pesquisa não pode ser vazio.");
        RuleFor(pesquisa => pesquisa.Inicio).NotEmpty().WithMessage("Data de início da pesquisa não pode ser vazia.");
        RuleFor(pesquisa => pesquisa.Fim).NotEmpty().WithMessage("Data de fim da pesquisa não pode ser vazia.");
    }
}