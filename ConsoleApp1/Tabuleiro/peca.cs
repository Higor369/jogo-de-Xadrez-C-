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
        public TabuleiroDoJogo tabuleiro { get; set; }
        

        public Peca( Cores cor, TabuleiroDoJogo tabuleiro)
        {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.quantidadeDeMovimentos = 0;
        }
        public void IncrementaMovimento()
        {
            quantidadeDeMovimentos++;
        }

    }
}
