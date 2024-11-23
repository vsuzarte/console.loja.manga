public class Program
{
    private static void Main(string[] args)
    {
        bool finalizarSistema = false;

        //Enquanto for true, ele continua executando
        while (!finalizarSistema) {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          Bem-vindo à Loja de Mangas     ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Área Administrativa");
            Console.WriteLine("0. Sair");
            Console.WriteLine("=========================================");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

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
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("                Cadastro                 ");
                    Console.WriteLine("=========================================");

                    Console.Write("Digite o nome do mangá: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite o nome do autor: ");
                    string autor = Console.ReadLine();
                    
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
                string valorDigitado = Console.ReadLine();
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
}