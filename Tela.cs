using tabuleiro;
using System;
using Xadrez;
namespace Xadrez_Console
{
    class Tela
    {
        public static void imprimirPartida(PartidadeXadrez partida)
        {
            imprimirtabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!!!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE");
                Console.WriteLine($"Vencedor: {partida.jogadorAtual}");
            }
            
        }
        public static void imprimirPecasCapturadas(PartidadeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.WriteLine(" Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.WriteLine(" Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(var x in conjunto)
            {
                Console.Write($"{x}, ");
            }
            Console.Write("]");

        }
        public static void imprimirtabuleiro(Tabuleiro tab)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoClaro = ConsoleColor.Black;       // quase neutro
            ConsoleColor fundoEscuro = ConsoleColor.DarkGray;   // tom suave

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    Console.BackgroundColor = (i + j) % 2 == 0 ? fundoClaro : fundoEscuro;
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine("  a b c d e f g h");
        }


        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + " ");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; // Mais suave
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Suave para peças pretas
                }
                Console.Write(peca + " ");
            }
            Console.ResetColor(); // sempre resetar depois
        }

        public static void imprimirtabuleiro(Tabuleiro tab, bool[,] possicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoClaro = ConsoleColor.Black;
            ConsoleColor fundoEscuro = ConsoleColor.DarkGray;
            ConsoleColor fundoPossivel = ConsoleColor.Red; // cor de destaque suave

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (possicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoPossivel;
                    }
                    else
                    {
                        Console.BackgroundColor = (i + j) % 2 == 0 ? fundoClaro : fundoEscuro;
                    }

                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine("  a b c d e f g h");
        }

    }
}
