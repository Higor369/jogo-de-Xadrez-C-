using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;

namespace Xadrez_Game.Xadrez
{
    class PartidaDeXadres
    {
        public TabuleiroDoJogo tab { get; private set; }
        private int turno;
        private Cores jogadorAtual;

        public PartidaDeXadres()
        {
            tab = new TabuleiroDoJogo(8, 8);
            turno = 1;
            jogadorAtual = Cores.Branca;
            ColocarPecas();
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementaMovimento();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(Cores.Preta, tab), new PosicaoXadrex('c', 1).ConvertePosicao());
        }
       
    }
}
