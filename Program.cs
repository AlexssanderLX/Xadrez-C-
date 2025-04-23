using tabuleiro;
using Xadrez_Console;
namespace xadrez_console 
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Tela.imprimirtabuleiro(tab);
            Console.WriteLine();
        }
    }
}
