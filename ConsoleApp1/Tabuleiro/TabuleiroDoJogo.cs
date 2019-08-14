using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Game.Tabuleiro
{
    class TabuleiroDoJogo
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public TabuleiroDoJogo(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }
        public Peca RetornaPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public void ColocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }
    }
}
