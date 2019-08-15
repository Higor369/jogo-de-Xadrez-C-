using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;
using Xadrez_Game.Xadrez;

namespace Xadrez_Game
{
    class OperaçoesComTela
    {
        public static void ImprimeTabuleiro(TabuleiroDoJogo tab)// varre a matriz e imprime o tabuleiro 
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.RetornaPeca(i, j) == null) 
                    {
                        Console.Write("- "); // se não tem peça ganha um traço 
                    }
                    else
                    {
                        OperaçoesComTela.ImprimirPeca(tab.RetornaPeca(i,j)); // se tiver, ganha a peça 
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
                ConsoleColor aux = Console.ForegroundColor; // altera a cor das peças pretas 
                Console.ForegroundColor = ConsoleColor.DarkGreen; // cor verde escura 
                Console.WriteLine(peca);
                Console.ForegroundColor = aux;
            }
        }
        public static PosicaoXadrex LerPosicaoTeclado()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrex(coluna, linha); // converte as coordenas digitadas em coordenadas da matriz
        }
    }
}
