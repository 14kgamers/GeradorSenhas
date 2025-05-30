using System;
using System.Text;

class GeradorDeSenhas
{
    static void Main()
    {
        Console.WriteLine("Gerador de Senhas\n");

        Console.Write("Digite o tamanho da senha: ");
        int tamanho = int.Parse(Console.ReadLine());

        Console.Write("Incluir letras maiúsculas? (s/n): ");
        bool usarMaiusculas = Console.ReadLine().ToLower() == "s";

        Console.Write("Incluir letras minusculas? (s/n): ");
        bool usarMinusculas = Console.ReadLine().ToLower() == "s";

        Console.Write("Incluir números ? (s/n): ");
        bool usarNumeros = Console.ReadLine().ToLower() == "s";

        Console.Write("Incluir símbolos? (s/n): ");
        bool usarSimbolos = Console.ReadLine().ToLower() == "s";

        string senha = GerarSenha(tamanho, usarMaiusculas, usarMinusculas, usarNumeros, usarSimbolos);

        Console.WriteLine($"\nSenha gerada: {senha}");
        Console.WriteLine("\nPrecione ENTER para sair.");
        Console.ReadLine();
    }
    static string GerarSenha(int tamanho, bool maiuscula, bool minusculas, bool numeros, bool simbolos)
    {
        const string letrasMainsculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string letrasMinusculas = "abcdefghijklmnopqrstuvwxyz";
        const string digitos = "0123456789";
        const string caracteresSimbolos = "!@#$%^&*()-_=+[]{};:,.<>?";

        StringBuilder caracteresPermitidos = new StringBuilder();

        if (maiuscula) caracteresPermitidos.Append(letrasMainsculas);
        if (minusculas) caracteresPermitidos.Append(letrasMinusculas);
        if (numeros) caracteresPermitidos.Append(digitos);
        if (simbolos) caracteresPermitidos.Append(caracteresSimbolos);

        if (caracteresPermitidos.Length == 0)
            return "Erro: Nenhum tipo de caractere selecionado.";

        Random random = new Random();
        StringBuilder senha = new StringBuilder();

        for (int i = 0; i < tamanho; i++)
        {
            int index = random.Next(caracteresPermitidos.Length);
            senha.Append(caracteresPermitidos[index]);
        }
        return senha.ToString();
    }
}