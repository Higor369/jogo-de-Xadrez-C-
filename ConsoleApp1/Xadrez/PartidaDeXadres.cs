using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;

namespace Xadrez_Game.Xadrez
{
    class PartidaDeXadres
    {
        public TabuleiroDoJogo tab { get; private set; }
        public int turno { get; private set; }
        public Cores jogadorAtual { get; private set; }
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
        public void RealizaJogada(Posicao origem, Posicao destino) // metodo que realiza a jogada , muda o turno e o jogador atual
        {
            ExecutaMovimento(origem,destino);
            turno++;
            MudaJogador();
        }
        private void MudaJogador()
        {
            if (jogadorAtual == Cores.Branca)
            {
                jogadorAtual = Cores.Preta;
            }
            else
            {
                jogadorAtual = Cores.Branca;
            }
        }
        public void ValidarPosicaoOrigem(Posicao pos) //valida se a posição escolhida tem uma peça, e se ela pode ser movida 
        {
            if (tab.peca(pos) == null) //a peça deve existir 
            {
                throw new TabuleiroExption("não existe peça na posição informada");
            }
            if (jogadorAtual != tab.peca(pos).cor) //deve ser a peça do jogador atual 
            {
                throw new TabuleiroExption("é a vez do outro jogador");
            }
            if (!tab.peca(pos).ExisteMovPossivel()) // a peça precisa ter movimentos possiveis 
            {
                throw new TabuleiroExption("nenhum movimento Possivel para essa peça");
            }
        }
        public void ValidaPosicaoDestiono(Posicao origem , Posicao destino)
        {
            if (!tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroExption("Possicao de destino Invalida");
            }
        }
       
    }
}
