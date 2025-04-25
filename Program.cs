using tabuleiro;
using Xadrez_Console;
using Xadrez;
namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidadeXadrez partida = new PartidadeXadrez();
                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirtabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
