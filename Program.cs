using tabuleiro;
using Xadrez_Console;
using Xadrez;
namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez posx = new PosicaoXadrez('a', 1);
            Console.WriteLine(posx);
            Console.WriteLine(posx.toPosicao());
        }
    }
}
