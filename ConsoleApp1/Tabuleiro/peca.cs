using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Game.Tabuleiro
{
     abstract class  Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; set; }
        public TabuleiroDoJogo tab { get; set; }
        

        public Peca( TabuleiroDoJogo tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tabuleiro;
            this.qteMovimentos = 0;
        }
        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }
        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }
        public abstract bool[,] MovimentosPossieis();

        public bool ExisteMovPossivel() // havalia se tem ao menos um movimento possivel para a peça
        {
            bool[,] mat = MovimentosPossieis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
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
            return MovimentosPossieis()[pos.linha, pos.coluna];
        }

        

    }
}
