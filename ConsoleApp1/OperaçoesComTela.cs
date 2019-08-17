using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;
using Xadrez_Game.Xadrez;

namespace Xadrez_Game
{
    class OperaçoesComTela
    {
        public static void ImprimeTabuleiro(TabuleiroDoJogo tab)// varre a matriz e imprime o tabuleiro sem posicoes possiveis 
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    ImprimirPeca(tab.RetornaPeca(i, j));

                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimeTabuleiro(TabuleiroDoJogo tab, bool[,] posicoesPossiveis)// varre a matriz e imprime o tabuleiro com posicoes possiveis 
        {
            ConsoleColor fundoO = Console.BackgroundColor;
            ConsoleColor fundoD = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoD;

                    }
                    else
                    {
                        Console.BackgroundColor = fundoO;
                    }

                    ImprimirPeca(tab.RetornaPeca(i, j));
                    Console.BackgroundColor = fundoO;
                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h \n");
            Console.BackgroundColor = fundoO;

        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- "); // se não tem peça ganha um traço 
            }
            else // se tiver peça na posicao informada, ela será impressa 
            {
                if (peca.cor == Cores.Branca)
                {

                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor; // altera a cor das peças pretas 
                    Console.ForegroundColor = ConsoleColor.DarkGreen; // cor verde escura 
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" "); // se não tem peça ganha um traço
            }

        }
        public static PosicaoXadrex LerPosicaoTeclado()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = (int)Char.GetNumericValue(s[1]);
            return new PosicaoXadrex(coluna, linha); // converte as coordenas digitadas em coordenadas da matriz
        }
        public static void ImprimePartida(PartidaDeXadres partida)
        {
            Console.Clear();
            ImprimeTabuleiro(partida.tab);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($" turno: {partida.turno} \n Jogador atual: {partida.jogadorAtual}");
        }
        public static void ImprimirPecasCapturadas(PartidaDeXadres partida)
        {
            Console.WriteLine("Pecas Capturadas");
            Console.WriteLine("Brancas:");
            ImprimirConjunto(partida.PecasCapturadas(Cores.Branca));
            Console.WriteLine("Pretas:");
            ImprimirConjunto(partida.PecasCapturadas(Cores.Branca));
        }
        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("] \n");
        }

    }
}
