using Xadrez_Game.Tabuleiro;

namespace Xadrez_Game.Xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadres partida;
        public Peao( TabuleiroDoJogo tab, Cor cor, PartidaDeXadres partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override bool[,] MovimentosPossieis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca) // peao branco só anda para o norte
            {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(p2) && Livre(p2) && tab.posicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos)) // se existe inimigo nas diagonais logo a frente, ele pode andar para lá
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // #jogadaespecial en passant
                if (posicao.linha == 3) // valido em uma unica coluna em especial 
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.VulneravelEnPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.VulneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }
            }
            else //peao preto só anda para o sul
            {
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(p2) && Livre(p2) && tab.posicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos)) // se existe inimigo na posicao das diagonais a frente, ele pode mover pra la 
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            if (posicao.linha == 4) //passant, valido em uma linha especifica 
            {
                Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                if (tab.posicaoValida(esquerda) && ExisteInimigo(esquerda) && tab.peca(esquerda) == partida.VulneravelEnPassant)
                {
                    mat[esquerda.linha + 1, esquerda.coluna] = true;
                }
                Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                if (tab.posicaoValida(direita) && ExisteInimigo(direita) && tab.peca(direita) == partida.VulneravelEnPassant)
                {
                    mat[direita.linha + 1, direita.coluna] = true;
                }
            }
            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }
        private bool Livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }


    }
}
