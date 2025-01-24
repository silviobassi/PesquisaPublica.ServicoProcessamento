using FluentValidation;
using ServicoProcessamento.Communication.Requests;
using ServicoProcessamento.Pesquisa.Extensions;

namespace ServicoProcessamento.Pesquisa.CreatePesquisa;

public class CreatePesquisaValidator : AbstractValidator<CreatePesquisaRequest>
{
    public CreatePesquisaValidator()
    {
        RuleFor(pesquisa => pesquisa.Codigo).NotEmpty().WithMessage("Código da pesquisa não pode ser vazio.");

        RuleFor(pesquisa => pesquisa.Inicio)!.ValidatorDataInicio();
        RuleFor(pesquisa => pesquisa.Fim)!.ValidatorDataFim();
    }
}