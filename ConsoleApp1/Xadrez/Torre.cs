using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;

namespace Xadrez_Game.Xadrez
{
    class Torre : Peca
    {
        public Torre(Cores cor, TabuleiroDoJogo tab) : base(cor, tab)
        {

        }

        private bool PodeMover(Posicao pos)
        {
            
            Peca p = tabuleiro.RetornaPeca(pos.Linha, pos.Coluna);
            return p == null || p.cor != this.cor; // valida se existe peça adversaria ou espaço em branco na posicao, se sim, pode mover 
        }

        public override bool[,] MovimentosPossieis()
        {

            bool[,] matTemp = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0); //instanciada com valores irrelevantes apenas 

            //norte 
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna); // define posiçao atual da peça e havalia as casas acima
            while(tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true; // se a posicao for livre ou de peça de cor diferetente, ele pode continuar se movendo
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != this.cor)
                {
                    break; // interrompe a iteraçao após encontrar uma peça de outra cor 
                }
                pos.Linha = pos.Linha -1;
            }

            // sul
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna); // define posiçao atual da peça e havalia as casas acima
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true; // se a posicao for livre ou de peça de cor diferetente, ele pode continuar se movendo
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != this.cor)
                {
                    break; // interrompe a iteraçao após encontrar uma peça de outra cor 
                }
                pos.Linha = pos.Linha + 1;
            }

            // leste 
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1); // define posiçao atual da peça e havalia as casas acima
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true; // se a posicao for livre ou de peça de cor diferetente, ele pode continuar se movendo
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != this.cor)
                {
                    break; // interrompe a iteraçao após encontrar uma peça de outra cor 
                }
                pos.Coluna = pos.Coluna + 1;
            }

            // oeste 
            pos.DefinirValores(posicao.Linha, posicao.Coluna -1); // define posiçao atual da peça e havalia as casas acima
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true; // se a posicao for livre ou de peça de cor diferetente, ele pode continuar se movendo
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != this.cor)
                {
                    break; // interrompe a iteraçao após encontrar uma peça de outra cor 
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return matTemp;

        }

        public override string ToString()
        {
            return "T";
        }
    }
}