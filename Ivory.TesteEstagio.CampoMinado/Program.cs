using System;
using System.Collections.Generic;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);
            Console.WriteLine();

            // Realize sua codificação a partir deste ponto, boa sorte!

            // Instanciando um novo vetor, listas e randoms que serão importantes no futuro
            string[] linhas = campoMinado.Tabuleiro.Split("\n");
            List<int> listaPosicaoLinha = new List<int>();
            List<int> listaPosicaoColuna = new List<int>();
            Random randColum = new Random();
            Random randRow = new Random();

            // Condicional para que percorra os campos do tabuleiro garantindo que todos sejam abertos
            while (campoMinado.Tabuleiro.Contains('-'))
            {
                int k = randRow.Next(9);
                int l = randColum.Next(9);

                if (linhas[k][l] == '-')
                {
                    campoMinado.Abrir(k+1, l+1);
                }

            }
            Console.WriteLine("Tabuleiro com todos os campos em aberto!\n");
            Console.WriteLine(campoMinado.Tabuleiro);
            Console.WriteLine();

            // Instanciando um novo vetor, com base no tabuleiro com todas as casas reveladas e percorrendo ele armazenando as informações das posições em uma lista
            string[] linhasReveladas = campoMinado.Tabuleiro.Split("\n");

            for(int i = 0; i <= 8; i++)
            {
                for(int j = 0; j <= 8; j++)
                {
                    if (linhasReveladas[i][j] == '0' || linhasReveladas[i][j] == '1' || linhasReveladas[i][j] == '2' || linhasReveladas[i][j] == '3' || linhasReveladas[i][j] == '4')
                    {
                        listaPosicaoLinha.Add(i);
                        listaPosicaoColuna.Add(j);
                    }
                }
            }

            // Jogando novamente, agora abriremos apenas as casas que aprendemos que não possui bombas

            var campoMinadoNovo = new CampoMinado();

            // Adicionando uma condicional com o status do jogo para garantir que abriremos todos os campos sem bombas, se algo der errado será apresentado mensagem de explosão

            while(campoMinadoNovo.JogoStatus == 0)
            {
                for (int m = 0; m < listaPosicaoColuna.Count; m++)
                {
                    campoMinadoNovo.Abrir(listaPosicaoLinha[m] + 1, listaPosicaoColuna[m] + 1);
                }
                Console.WriteLine("Tabuleiro com os campos sem bombas\n");
                Console.WriteLine(campoMinadoNovo.Tabuleiro);

            }
            if (campoMinadoNovo.JogoStatus == 2)
            {
                Explosao();
            }

            else
            {
                SaudacaoVitoria();
            }

            static void Explosao()
            {
                Console.WriteLine("\nBOOOOOOM! Você encontrou uma mina terrestre");
                Console.WriteLine("                 _.-^^---....,,--       ");
                Console.WriteLine("             _--                  --_  ");
                Console.WriteLine("            <                        >)");
                Console.WriteLine("            |                         | ");
                Console.WriteLine("             _                   _./  ");
                Console.WriteLine("                ```--. . , ; .--'''       ");
                Console.WriteLine("                      | |   |             ");
                Console.WriteLine("                   .-=||  | |=-.   ");
                Console.WriteLine("                   `-=#$%&%$#=-'   ");
                Console.WriteLine("                      | ;  :|     ");
                Console.WriteLine("             _____.,-#%&$@%#&#~,._____");
                Console.WriteLine("\nInfelizmente o jogo acabou para você!");
            }

            void SaudacaoVitoria()
            {
                Console.WriteLine($"\nParabéns!! Você acaba de vencer o jogo");
                Console.WriteLine("\nTudo continua em paz e nada foi explodido");

            }
        }
    }
}
