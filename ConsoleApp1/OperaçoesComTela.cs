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
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.RetornaPeca(i, j) == null)
                    {
                        Console.WriteLine("- ");
                    }
                    else
                    {
                        Console.Write(tab.RetornaPeca(i, j));
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
