using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Game.Tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }

        public override string ToString()
        {
            return Linha + ", " + Coluna;
        }
        public void DefinirValores(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }
    }
}
