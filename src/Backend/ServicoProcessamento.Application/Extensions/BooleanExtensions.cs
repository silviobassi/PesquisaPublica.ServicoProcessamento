namespace ServicoProcessamento.Application.Extensions;

public static class BooleanExtensions
{
    public static bool IsFalse(this bool value) => !value;
    
    public static bool IsTrue(this bool value) => value;
}