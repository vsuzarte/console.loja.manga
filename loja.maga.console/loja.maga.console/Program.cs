using System.Drawing;

public class Program
{
    private static void Main(string[] args)
    {
        bool finalizarSistema = false;

        while (!finalizarSistema) {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          Bem-vindo à Loja de Mangas     ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Área Administrativa");
            Console.WriteLine("0. Sair");
            Console.WriteLine("=========================================");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? string.Empty;

            switch (opcao)
            {
                case "1":
                    MenuAdministrativo();
                    break;

                case "0":
                    Console.WriteLine("Saindo do sistema. Até logo!");
                    finalizarSistema = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void MenuAdministrativo()
    {
        bool finalizarADM = false;

        while (!finalizarADM) {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          Área Administrativa            ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Cadastrar Mangá");
            Console.WriteLine("0. Sair");
            Console.WriteLine("=========================================");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? string.Empty;

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("                Cadastro                 ");
                    Console.WriteLine("=========================================");

                    string nome = SolicitarValorTextual("Digite o nome do mangá: ");

                    string autor = SolicitarValorTextual("Digite o nome do autor: ");

                    double quantidadeEstoque = SolicitarValorDecimal("Digite a Quantidade de Estoque: ");

                    double preco = SolicitarValorDecimal("Digite o preço: ");

                    Console.WriteLine($"O Mangá {nome} do autor {autor} com quantidade em " +
                        $"estoque {quantidadeEstoque} e preço {preco} foi cadastrado " +
                        $"com sucesso. Pressione qualquer tecla para continuar.");
                    Console.ReadLine();
                    break;
                case "0":
                    Console.WriteLine("Saindo da Área Administrativa.");
                    finalizarADM = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static double SolicitarValorDecimal(string texto)
    {
        double valor = 0;
        bool valorValidado = false;

        do
        {
            try
            {
                Console.Write(texto);
                string valorDigitado = Console.ReadLine() ?? string.Empty;
                string valorCorreto = valorDigitado.Replace(".", ",");
                valor = Convert.ToDouble(valorCorreto);
                valorValidado = true;
            }
            catch (Exception)
            {
                Console.WriteLine($"O valor digitado não é um número decimal válido. Pressione qualquer tecla para tentar novamente.");
                Console.ReadLine();
            }
        }
        while (!valorValidado);

        return valor;
    }

    private static string SolicitarValorTextual(string texto)
    {
        bool valorValidado = false;
        string valor = "";

        do
        {
            Console.Write(texto);
            valor = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrEmpty(valor))
            {
                Console.WriteLine($"O texto digitado não válido. Pressione qualquer tecla para tentar novamente.");
                Console.ReadLine();
            }
            else
            {
                valorValidado = true;
            }
        }
        while (!valorValidado);

        return valor;
    }
}