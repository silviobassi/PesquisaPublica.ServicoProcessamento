using FluentValidation;

namespace ServicoProcessamento.Feature.Pesquisa.Extensions;

public static class ValidatorExtensions
{
    private const string RegexData = @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$";

    public static IRuleBuilderOptions<T, string> ValidatorDataInicio<T>(this IRuleBuilderInitial<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().WithMessage("Data do início da pesquisa não pode ser vazia.")
            .Matches(RegexData)
            .WithMessage("Data do início deve estar no formato 'yyyy-MM-ddTHH:mm:ss'.")!;
    }

    public static IRuleBuilderOptions<T, string> ValidatorDataFim<T>(this IRuleBuilderInitial<T, string> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().WithMessage("Data do fim da pesquisa não pode ser vazia.")
            .Matches(RegexData)
            .WithMessage("Data do fim deve estar no formato 'yyyy-MM-ddTHH:mm:ss'.")!;
    }
}