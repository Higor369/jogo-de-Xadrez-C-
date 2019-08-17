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
                PartidaDeXadres partida = new PartidaDeXadres();

                while (!partida.terminada)
                {

                    try
                    {
                        Console.Clear();
                        OperaçoesComTela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = OperaçoesComTela.LerPosicaoTeclado().ConvertePosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).MovimentosPossieis();

                        Console.Clear();
                        OperaçoesComTela.ImprimeTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = OperaçoesComTela.LerPosicaoTeclado().ConvertePosicao();
                        partida.ValidaPosicaoDestiono(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                OperaçoesComTela.ImprimirPartida(partida);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        } 
    
    }
}
