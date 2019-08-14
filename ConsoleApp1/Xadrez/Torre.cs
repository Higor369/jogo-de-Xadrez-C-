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

        public override string ToString()
        {
            return "T";
        }
    }
}