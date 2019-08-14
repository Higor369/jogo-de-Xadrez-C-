using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Game.Tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cores cor { get; protected set; }
        public int quantidadeDeMovimentos { get; set; }
        public TabuleiroDoJogo tabuleiro { get; protected set; }

        public Peca(Posicao posicao, Cores cor, TabuleiroDoJogo tabuleiro)
        {
            this.posicao = posicao;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.quantidadeDeMovimentos = 0;
        }
    }
}
