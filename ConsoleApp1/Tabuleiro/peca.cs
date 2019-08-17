using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Game.Tabuleiro
{
     abstract class  Peca
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
        public void DecrementarMovimento()
        {
            quantidadeDeMovimentos--;
        }
        public abstract bool[,] MovimentosPossieis();

        public bool ExisteMovPossivel() // havalia se tem ao menos um movimento possivel para a peça
        {
            bool[,] mat = MovimentosPossieis();
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool movimentoPossivel(Posicao pos)
        {
            return MovimentosPossieis()[pos.Linha, pos.Coluna];
        }

        

    }
}
