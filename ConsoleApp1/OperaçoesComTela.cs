using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;
namespace Xadrez_Game
{
    class OperaçoesComTela
    {
        public static void ImprimeTabuleiro(TabuleiroDoJogo tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.RetornaPeca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        OperaçoesComTela.ImprimirPeca(tab.RetornaPeca(i,j);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.cor == Cores.Branca)
            {
      
                Console.WriteLine(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
