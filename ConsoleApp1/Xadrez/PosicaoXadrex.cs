using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;

namespace Xadrez_Game.Xadrez
{
    class PosicaoXadrex
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrex(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }

        public Posicao ConvertePosicao()
        {
            
            return new Posicao(8-linha,coluna - 'a'); // cloca as linhas de forma decresente, como no xadez , e o char para o int correspondente
                                                      // char 'a' para int é 1, 1- coluna deixa as linhas de 0 a 7 como na matriz 
                                                                                 
        }
    }
}
