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
                    ImprimirPeca(tab.retornaPeca(i, j));

                }

                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h \n");
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
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoD;

                    }
                    else
                    {
                        Console.BackgroundColor = fundoO;
                    }

                    ImprimirPeca(tab.retornaPeca(i, j));
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
                if (peca.cor == Cor.Branca)
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

            string t = Console.ReadLine();
            string s = t.ToLower();
            int resultadoDaConvercao;
            if (s[0].GetType() == typeof(char) || int.TryParse(s[1] + " ",out resultadoDaConvercao) || s.Length != 2)
            {
                throw new TabuleiroException("por favor, digite uma letra e um numero \n tecle enter para continuar");
            }
            
            char coluna = s[0];
            int linha = (int)Char.GetNumericValue(s[1]);
            return new PosicaoXadrex(coluna, linha); // converte as coordenas digitadas em coordenadas da matriz
        }
        public static void ImprimirPartida(PartidaDeXadres partida)
        {
            Console.Clear();
            ImprimeTabuleiro(partida.tab);
            ImprimirPecasCapturadas(partida);
            if (!partida.terminada)
            {
                Console.WriteLine();
                Console.WriteLine($" turno: {partida.turno} \n Jogador atual: {partida.jogadorAtual}");
                if (partida.xeque)
                {
                    Console.WriteLine("Xeque!");
                }

            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }
        public static void ImprimirPecasCapturadas(PartidaDeXadres partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            
        }
        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("] \n");
        }

    }
}
