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

                    Console.Write("Quantidade em estoque: ");
                    double quantidadeEstoque = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Preço: ");
                    double preco = Convert.ToDouble(Console.ReadLine());

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
}