using loja.manga.dominio;

public class Program
{
    private static List<Manga> listaDeMangas = new List<Manga>();

    private static void Main(string[] args)
    {
        bool finalizarSistema = false;
        listaDeMangas.AddRange(PreencherListaDeMangas());

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
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Saindo do sistema. Até logo!");
                    Console.WriteLine("=========================================");
                    finalizarSistema = true;
                    break;

                default:
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.WriteLine("=========================================");
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
            Console.WriteLine("1. Cadastrar Mangás");
            Console.WriteLine("2. Listar Mangás");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? string.Empty;

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("                Cadastro                 ");
                    Console.WriteLine("=========================================");

                    var manga = new Manga();

                    manga.Id = listaDeMangas.Count + 1;
                    manga.Nome = SolicitarValorTextual("Digite o nome do mangá: ");
                    manga.Autor = SolicitarValorTextual("Digite o nome do autor: ");
                    manga.QuantidadeEstoque = SolicitarValorInteiro("Digite a Quantidade de Estoque: ");
                    manga.ValorUnitario = SolicitarValorDecimal("Digite o valor unitário: ");
                    
                    listaDeMangas.Add(manga);

                    Console.WriteLine("=========================================");
                    Console.WriteLine("Mangá Cadastradrado com sucesso");
                    Console.WriteLine(manga.ImprimirVariasLinhas());
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Pressione qualquer tecla para continuar.");
                    Console.ReadLine();
                    
                    break;
                case "2":
                    ListarMangas();
                    break;
                case "0":
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Saindo da Área Administrativa.");
                    Console.WriteLine("=========================================");
                    finalizarADM = true;
                    break;

                default:
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.WriteLine("=========================================");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void ListarMangas()
    {
        Console.Clear();
        Console.WriteLine("=========================================");
        Console.WriteLine("           Lista de Mangás               ");
        Console.WriteLine("=========================================");

        if (listaDeMangas.Count == 0)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Nenhum mangá cadastrado.");
            Console.WriteLine("=========================================");
        }
        else
        {
            foreach (var manga in listaDeMangas)
            {
                Console.WriteLine(manga.ImprimirEmLinha());
            }
        }
        Console.WriteLine("=========================================");
        Console.WriteLine("Pressione qualquer tecla para voltar.");
        Console.WriteLine("=========================================");
        Console.ReadKey();
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
                Console.WriteLine("=========================================");
                Console.WriteLine($"O valor digitado não é um número decimal válido. Pressione qualquer tecla para tentar novamente.");
                Console.WriteLine("=========================================");
                Console.ReadLine();
            }
        }
        while (!valorValidado);

        return valor;
    }

    private static int SolicitarValorInteiro(string texto)
    {
        int valor = 0;
        bool valorValidado = false;

        do
        {
            try
            {
                Console.Write(texto);
                string valorDigitado = Console.ReadLine() ?? string.Empty;
                valor = Convert.ToInt32(valorDigitado);
                valorValidado = true;
            }
            catch (Exception)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine($"O valor digitado não é um número inteiro válido. Pressione qualquer tecla para tentar novamente.");
                Console.WriteLine("=========================================");
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
                Console.WriteLine("=========================================");
                Console.WriteLine($"O texto digitado não válido. Pressione qualquer tecla para tentar novamente.");
                Console.WriteLine("=========================================");
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

    public static List<Manga> PreencherListaDeMangas()
    {
        return new List<Manga>
        {
            new() { Id = 1, Nome = "Naruto", Autor = "Masashi Kishimoto", QuantidadeEstoque = 15, ValorUnitario = 29.90 },
            new() { Id = 2, Nome = "One Piece", Autor = "Eiichiro Oda", QuantidadeEstoque = 10, ValorUnitario = 32.90 },
            new() { Id = 3, Nome = "Attack on Titan", Autor = "Hajime Isayama", QuantidadeEstoque = 8, ValorUnitario = 34.50 },
            new() { Id = 4, Nome = "Dragon Ball", Autor = "Akira Toriyama", QuantidadeEstoque = 20, ValorUnitario = 28.90 },
            new() { Id = 5, Nome = "Demon Slayer", Autor = "Koyoharu Gotouge", QuantidadeEstoque = 12, ValorUnitario = 30.90 }
        };
    }
}