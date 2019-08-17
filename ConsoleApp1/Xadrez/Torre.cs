using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;

namespace Xadrez_Game.Xadrez
{
    class Torre : Peca
    {
        public Torre(TabuleiroDoJogo tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        private bool PodeMover(Posicao pos)
        {
            
            Peca p = tab.retornaPeca(pos.linha, pos.coluna);
            return p == null || p.cor != this.cor; // valida se existe peça adversaria ou espaço em branco na posicao, se sim, pode mover 
        }

        public override bool[,] MovimentosPossieis()
        {

            bool[,] matTemp = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0); //instanciada com valores irrelevantes apenas 

            //norte 
            pos.definirValores(posicao.linha - 1, posicao.coluna); // define posiçao atual da peça e havalia as casas acima
            while(tab.posicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.linha, pos.coluna] = true; // se a posicao for livre ou de peça de cor diferetente, ele pode continuar se movendo
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break; // interrompe a iteraçao após encontrar uma peça de outra cor 
                }
                pos.linha = pos.linha -1;
            }

            // sul
            pos.definirValores(posicao.linha + 1, posicao.coluna); // define posiçao atual da peça e havalia as casas acima
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.linha, pos.coluna] = true; // se a posicao for livre ou de peça de cor diferetente, ele pode continuar se movendo
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break; // interrompe a iteraçao após encontrar uma peça de outra cor 
                }
                pos.linha = pos.linha + 1;
            }

            // leste 
            pos.definirValores(posicao.linha, posicao.coluna + 1); // define posiçao atual da peça e havalia as casas acima
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.linha, pos.coluna] = true; // se a posicao for livre ou de peça de cor diferetente, ele pode continuar se movendo
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break; // interrompe a iteraçao após encontrar uma peça de outra cor 
                }
                pos.coluna = pos.coluna + 1;
            }

            // oeste 
            pos.definirValores(posicao.linha, posicao.coluna -1); // define posiçao atual da peça e havalia as casas acima
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.linha, pos.coluna] = true; // se a posicao for livre ou de peça de cor diferetente, ele pode continuar se movendo
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break; // interrompe a iteraçao após encontrar uma peça de outra cor 
                }
                pos.coluna = pos.coluna - 1;
            }

            return matTemp;

        }

        public override string ToString()
        {
            return "T";
        }
    }
}