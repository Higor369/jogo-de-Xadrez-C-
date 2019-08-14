using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Game.Tabuleiro
{
    class TabuleiroExption : Exception
    {
        public TabuleiroExption(string msg) : base(msg)
        {

        }
    }
}
