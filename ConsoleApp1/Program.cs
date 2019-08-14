using System;
using Xadrez_Game.Tabuleiro;
using Xadrez_Game.Xadrez;

namespace Xadrez_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TabuleiroDoJogo tab = new TabuleiroDoJogo(8, 8);
                tab.ColocarPeca(new Torre(Cores.Preta, tab), new Posicao(0, 0));
                OperaçoesComTela.ImprimeTabuleiro(tab);

            }
            catch (TabuleiroExption e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
