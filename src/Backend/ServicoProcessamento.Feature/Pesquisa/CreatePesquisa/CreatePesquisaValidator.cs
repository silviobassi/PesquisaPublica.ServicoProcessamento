using FluentValidation;
using ServicoProcessamento.Communication.Pesquisa.Requests;
using ServicoProcessamento.Feature.Pesquisa.Extensions;

namespace ServicoProcessamento.Feature.Pesquisa.CreatePesquisa;

public class CreatePesquisaValidator : AbstractValidator<CreatePesquisaRequest>
{
    public CreatePesquisaValidator()
    {
        RuleFor(pesquisa => pesquisa.Codigo).NotEmpty().WithMessage("Código da pesquisa não pode ser vazio.");

        RuleFor(pesquisa => pesquisa.Inicio)!.ValidatorDataInicio();
        RuleFor(pesquisa => pesquisa.Fim)!.ValidatorDataFim();
    }
}