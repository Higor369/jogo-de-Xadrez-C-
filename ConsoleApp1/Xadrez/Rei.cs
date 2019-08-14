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

        public override string ToString()
        {
            return "R";
        }
    }
}
