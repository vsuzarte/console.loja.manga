namespace loja.maga.console
{
    public static class ConsoleVisualizacao
    {
        public static void CriarTituloInicial()
        {
            Console.WriteLine("###                  ##                        ###                                                             ##");
            Console.WriteLine(" ##                                             ##");
            Console.WriteLine(" ##      ####       ###    #####                ##   ######            ##   ##    ####    #####   ######     ####");
            Console.WriteLine(" ##     ##  ##       ##       ##             #####   ##  ##            #######      ##   ##  ##   ##  ##       ##");
            Console.WriteLine(" ##     ##  ##       ##    #####            ##  ##   ######            ## # ##   #####   ##  ##   ##  ##    #####");
            Console.WriteLine(" ##     ##  ##   ##  ##   ##  ##            ##  ##   ##                ##   ##  ##  ##   ##  ##    #####   ##  ##");
            Console.WriteLine(" ##     ##  ##   ##  ##   ##  ##            ##  ##   ##                ##   ##  ##  ##   ##  ##    #####   ##  ##");
            Console.WriteLine("####     ####    ##  ##   ######            ######   #####             ##   ##  ######   ##  ##       ##    #####");
            Console.WriteLine("                  ####                                                                             #####");
        }

        public static void CriarTitulo(string titulo)
        {
            Console.Clear();
            CriarDivisor();
            Console.WriteLine($"{titulo}");
            CriarDivisor();
        }

        public static void CriarAlerta(string alerta)
        {
            CriarDivisor();
            Console.WriteLine(alerta);
            CriarDivisor();
            Console.ReadKey();
        }

        public static void CriarMenu(string[] menu)
        {
            CriarDivisor();

            for (int i = 0; i < menu.Length; i++)
            {
                Console.Write($" {i + 1} - {menu[i]} | ");
            }
            Console.WriteLine();
            CriarDivisor(); 
        }

        public static void OpcaoInvalida()
        {
            CriarAlerta("Opção inválida! Pressione qualquer tecla para tentar novamente.");
        }

        public static double SolicitarValorDecimal(string texto)
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
                    CriarAlerta("O valor digitado não é um número decimal válido.\n" +
                                "Pressione qualquer tecla para tentar novamente.");
                }
            }
            while (!valorValidado);

            return valor;
        }

        public static int SolicitarValorInteiro(string texto)
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
                    CriarAlerta("O valor digitado não é um número inteiro válido.\n" +
                                "Pressione qualquer tecla para tentar novamente.");
                }
            }
            while (!valorValidado);

            return valor;
        }

        public static string SolicitarValorTextual(string texto)
        {
            bool valorValidado = false;
            string valor = "";

            do
            {
                Console.Write(texto);
                valor = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(valor))
                {
                    CriarAlerta("O texto digitado não válido.\n" +
                                "Pressione qualquer tecla para tentar novamente.");
                }
                else
                {
                    valorValidado = true;
                }
            }
            while (!valorValidado);

            return valor;
        }

        private static void CriarDivisor() => Console.WriteLine(new string('=', 40));
    }
}
