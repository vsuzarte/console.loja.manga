using loja.maga.console;
using loja.manga.dominio;
using System;

public class Program
{
    private static List<Manga> listaDeMangas = new List<Manga>();

    private static void Main(string[] args)
    {
        bool finalizarSistema = false;
        listaDeMangas.AddRange(PreencherListaDeMangas());

        while (!finalizarSistema) {
            ConsoleVisualizacao.CriarTituloInicial();
            ConsoleVisualizacao.CriarMenu(["Área Administrativa", "Sair"]);
            
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? string.Empty;

            switch (opcao)
            {
                case "1":
                    MenuAdministrativo();
                    break;

                case "2":
                    ConsoleVisualizacao.CriarTitulo("Saindo do sistema. Até logo!");
                    finalizarSistema = true;
                    break;

                default:
                    ConsoleVisualizacao.OpcaoInvalida();
                    break;
            }
        }
    }

    private static void MenuAdministrativo()
    {
        bool finalizarADM = false;

        while (!finalizarADM) {
            ConsoleVisualizacao.CriarTitulo("Área Administrativa");
            ConsoleVisualizacao.CriarMenu(["Cadastrar Mangás", "Listar Mangás", "Buscar Mangás", "Editar", "Excluir", "Sair"]);

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? string.Empty;

            switch (opcao)
            {
                case "1":
                    CadastrasMagana();
                    break;

                case "2":
                    ListarMangas();
                    break;

                case "3":
                    BuscarMangas();
                    break;

                case "4":
                    EditarMangas();
                    break;

                case "5":
                    //ExcluirMangas();
                    break;

                case "6":
                    ConsoleVisualizacao.CriarTitulo("Saindo da Área Administrativa.");
                    finalizarADM = true;
                    break;

                default:
                    ConsoleVisualizacao.OpcaoInvalida();
                    break;
            }
        }
    }

    private static void BuscarMangas()
    {
        bool finalizarBusca = false;

        while (!finalizarBusca)
        {
            ConsoleVisualizacao.CriarTitulo("Buscar Mangás");
            ConsoleVisualizacao.CriarMenu(["Buscar por Id", "Buscar por Nome", "Buscar por Autor", "Sair"]);

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? string.Empty;

            switch (opcao)
            {
                case "1":
                    BuscarMangaPorId();
                    break;

                case "2":
                    BuscarMangaPorNome();
                    break;

                case "3":
                    BuscarMangaPorAutor();
                    break;

                case "4":
                    ConsoleVisualizacao.CriarTitulo("Buscar por Id");
                    finalizarBusca = true;
                    break;

                default:
                    ConsoleVisualizacao.OpcaoInvalida();
                    break;
            }
        }
    }

    private static void CadastrasMagana()
    {
        ConsoleVisualizacao.CriarTitulo("Cadastras Mangá");

        var manga = new Manga();

        manga.Id = listaDeMangas.Count + 1;

        manga.Nome = ConsoleVisualizacao.SolicitarValorTextual("Digite o nome do mangá: ");
        manga.Autor = ConsoleVisualizacao.SolicitarValorTextual("Digite o nome do autor: ");
        manga.QuantidadeEstoque = ConsoleVisualizacao.SolicitarValorInteiro("Digite a Quantidade de Estoque: ");
        manga.ValorUnitario = ConsoleVisualizacao.SolicitarValorDecimal("Digite o valor unitário: ");

        listaDeMangas.Add(manga);

        ConsoleVisualizacao.CriarAlerta($"{manga.ImprimirVariasLinhas()}\n" +
                                        $"Pressione qualquer tecla para continuar.");
    }

    private static void ListarMangas(bool emEdicao = false)
    {
        ConsoleVisualizacao.CriarTitulo("Lista de Mangás");

        if (listaDeMangas.Count == 0)
            ConsoleVisualizacao.CriarAlerta("Nenhum mangá cadastrado.");
        else
        {
            foreach (var manga in listaDeMangas)
            {
                Console.WriteLine(manga.ImprimirEmLinha());
            }
        }

        if(!emEdicao)
            ConsoleVisualizacao.CriarAlerta("Pressione qualquer tecla para voltar.");
    }

    public static void EditarMangas()
    {
        bool escolheuManga = false;
        Manga? manga = null;

        do
        {
            ConsoleVisualizacao.CriarTitulo("Editar Mangás");
            ListarMangas(emEdicao: true);
            int id = ConsoleVisualizacao.SolicitarValorInteiro("Digite o Id do mangá que deseja editar: ");

            manga = listaDeMangas.Find(manga => manga.Id == id);

            if (manga is null)
                ConsoleVisualizacao.CriarAlerta("Id digitado não existe. Pressione para tentar novamente.");
            else
                escolheuManga = true;
        }
        while (!escolheuManga);

        if(manga is not null)
        {
            manga.Nome = ConsoleVisualizacao.SolicitarValorTextual($"Digite o nome ({manga.Nome}): ");
            manga.Autor = ConsoleVisualizacao.SolicitarValorTextual($"Digite autor ({manga.Autor}): ");
            manga.ValorUnitario = ConsoleVisualizacao.SolicitarValorDecimal($"Digite o valor unitário ({manga.ValorUnitario}): ");
        }
    }

    private static void BuscarMangaPorId()
    {
        ConsoleVisualizacao.CriarTitulo("Buscar por Id");

        int id = ConsoleVisualizacao.SolicitarValorInteiro("Digite o id: ");
        var manga = listaDeMangas.Find(m => m.Id == id);
        MostrarResultadoBusca(manga);
    }

    private static void BuscarMangaPorNome()
    {
        ConsoleVisualizacao.CriarTitulo("Buscar por Nome");

        string nome = ConsoleVisualizacao.SolicitarValorTextual("Digite o nome: ");
        var manga = listaDeMangas.FindAll(m => m.Nome.ToLower().Contains(nome.ToLower()));

        MostrarResultadoBusca(manga);
    }

    private static void BuscarMangaPorAutor()
    {
        ConsoleVisualizacao.CriarTitulo("Buscar por Autor");

        string autor = ConsoleVisualizacao.SolicitarValorTextual("Digite o autor: ");
        var manga = listaDeMangas.FindAll(m => m.Autor.ToLower().Contains(autor.ToLower()));

        MostrarResultadoBusca(manga);
    }

    private static void MostrarResultadoBusca(Manga? manga)
    {
        if (manga is null)
            ConsoleVisualizacao.CriarAlerta($"Não foi possivel encontrar o mangá.\n" +
                                            $"Pressione qualquer tecla para fazer outra busca.");
        else
            ConsoleVisualizacao.CriarAlerta($"{manga.ImprimirVariasLinhas()}\n" +
                                            $"Pressione qualquer tecla para fazer outra busca.");
    }

    private static void MostrarResultadoBusca(List<Manga> mangas)
    {
        if (mangas.Count == 1)
            MostrarResultadoBusca(mangas.FirstOrDefault());
        else
            mangas.ForEach(manga => Console.WriteLine(manga.ImprimirEmLinha()));

        ConsoleVisualizacao.CriarAlerta("Pressione qualquer tecla para voltar.");
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