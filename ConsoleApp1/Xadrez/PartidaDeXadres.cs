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
        public bool terminada { get; private set; }

        public PartidaDeXadres()
        {
            tab = new TabuleiroDoJogo(8, 8);
            turno = 1;
            jogadorAtual = Cores.Branca;
            ColocarPecas();
            terminada = false;
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino) // retira a peça da origem e coloca no destino, se houver peça no destino, ele remove ela
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementaMovimento();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        private void ColocarPecas() // instancia a peça na posicao informada 
        {
            tab.ColocarPeca(new Torre(Cores.Preta, tab), new PosicaoXadrex('c', 1).ConvertePosicao());
        }
       
    }
}
