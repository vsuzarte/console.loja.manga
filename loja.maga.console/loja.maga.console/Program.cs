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
                    Console.Clear();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("          Área Administrativa            ");
                    Console.WriteLine("=========================================");
                    break;

                case "0":
                    Console.WriteLine("Saindo do sistema. Até logo!");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}