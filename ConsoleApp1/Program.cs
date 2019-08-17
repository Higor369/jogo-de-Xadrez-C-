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
                        OperaçoesComTela.ImprimePartida(partida);

                        Console.WriteLine("\n Digite a Peça de Origem: ");
                        Posicao origem = OperaçoesComTela.LerPosicaoTeclado().ConvertePosicao();
                        Console.WriteLine(origem);
                        partida.ValidarPosicaoOrigem(origem);


                        bool[,] possicoesPossiceis = partida.tab.peca(origem).MovimentosPossieis();

                        Console.Clear();
                        OperaçoesComTela.ImprimeTabuleiro(partida.tab, possicoesPossiceis);

                        Console.WriteLine("Digite a posição de Destino da Peça selecionada: ");
                        Posicao destino = OperaçoesComTela.LerPosicaoTeclado().ConvertePosicao();
                        partida.ValidaPosicaoDestiono(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroExption e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Tecle enter para realizar uma nova jogada");
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroExption e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
