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
                    Console.Clear();
                    OperaçoesComTela.ImprimeTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.WriteLine("Digite a Peça de Origem: ");
                    Posicao origem = OperaçoesComTela.LerPosicaoTeclado().ConvertePosicao();
                    Console.WriteLine(origem);

                    bool[,] possicoesPossiceis = partida.tab.peca(origem).MovimentosPossieis();

                    Console.Clear();
                    OperaçoesComTela.ImprimeTabuleiro(partida.tab, possicoesPossiceis);

                    Console.WriteLine("Digite a posição de Destino da Peça selecionada: ");
                    Posicao destino = OperaçoesComTela.LerPosicaoTeclado().ConvertePosicao();

                    partida.ExecutaMovimento(origem, destino);
                }
            }
            catch (TabuleiroExption e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
