using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;

namespace Xadrez_Game.Xadrez
{
    class Rei : Peca
    {
        public Rei( Cores cor , TabuleiroDoJogo tab) : base(cor, tab)
        {

        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = tabuleiro.RetornaPeca(pos.Linha, pos.Coluna);
            return p == null || p.cor != this.cor; //se a casa estiver vazia ou for peça de outra cor, pode mover 
        }

        public override bool[,] MovimentosPossieis()
        {
         
            bool[,] matTemp = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0,0); // instancia obj posicao apenas 

            //posicao norte 
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna); // recupera a casa que será havaliada
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos)) // se a casa estiver livre ou for uma peça de outra cor, pode mover 
            {                                                // metódos e condicionais abaixo  apenas alteram a casa havaliada, mas a logica é a mesma 
                matTemp[pos.Linha, pos.Coluna] = true;
            }
            // posicao nordeste
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true;
            }
            // posicao leste
            pos.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true;
            }
            //posicao sudeste 
            pos.DefinirValores(posicao.Linha +1, posicao.Coluna +1 );
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true;
            }
            // posicao sul 
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true;
            }
            // posicao sul doeste 
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna -1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true;
            }
            // posicao oeste
            pos.DefinirValores(posicao.Linha, posicao.Coluna -1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true;
            }
            // posicao noroeste 
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna -1);
            if (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                matTemp[pos.Linha, pos.Coluna] = true;
            }

            return matTemp;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
