using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Game.Tabuleiro;

namespace Xadrez_Game.Xadrez
{
    class PartidaDeXadres
    {
        public TabuleiroDoJogo tab { get; private set; }
        public int turno { get; private set; }
        public Cores jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> conjuntoPecasEmJogo;
        private HashSet<Peca> conjuntoPecasCapturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadres()
        {
            tab = new TabuleiroDoJogo(8, 8);
            turno = 1;
            jogadorAtual = Cores.Branca;
            conjuntoPecasEmJogo = new HashSet<Peca>();
            conjuntoPecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
            terminada = false;
            xeque = false;
        }
        public HashSet<Peca> PecasCapturadas(Cores cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in conjuntoPecasCapturadas)
            {
                if (item.cor == cor)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cores cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in conjuntoPecasEmJogo)
            {
                if (item.cor == cor)
                {
                    aux.Add(item);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino) // retira a peça da origem e coloca no destino, se houver peça no destino, ele remove ela
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementaMovimento();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                conjuntoPecasCapturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca) // metodo auxiliar para inserir pecas 
        {
            tab.ColocarPeca(peca, new PosicaoXadrex(coluna, linha).ConvertePosicao());
            conjuntoPecasEmJogo.Add(peca); // cloca peça no cnjunto 
        }

        private void ColocarPecas() // instancia as peças nas posicoes informadas 
        {
            ColocarNovaPeca('c', 1, new Torre(Cores.Preta, tab));

        }
        public void RealizaJogada(Posicao origem, Posicao destino) // metodo que realiza a jogada , muda o turno e o jogador atual
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(jogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroExption("você não pode colocar seu rei em xeque");
            }
            if (EstaEmXeque(Adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (TestaXequeMate(Adversaria(jogadorAtual)))
            {
                terminada = true; // se eu for realizada uma jogada que coloque o seu adversario em xequemate, a partida acaba 
            }
            else
            {
                turno++;
                MudaJogador();
            }
        }

        private void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarMovimento();
            if (pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                conjuntoPecasCapturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, origem);
        }

        private void MudaJogador()
        {
            if (jogadorAtual == Cores.Branca)
            {
                jogadorAtual = Cores.Preta;
            }
            else
            {
                jogadorAtual = Cores.Branca;
            }
        }
        public void ValidarPosicaoOrigem(Posicao pos) //valida se a posição escolhida tem uma peça, e se ela pode ser movida 
        {
            if (tab.peca(pos) == null) //a peça deve existir 
            {
                throw new TabuleiroExption("não existe peça na posição informada");
            }
            if (jogadorAtual != tab.peca(pos).cor) //deve ser a peça do jogador atual 
            {
                throw new TabuleiroExption("é a vez do outro jogador");
            }
            if (!tab.peca(pos).ExisteMovPossivel()) // a peça precisa ter movimentos possiveis 
            {
                throw new TabuleiroExption("nenhum movimento Possivel para essa peça");
            }
        }
        public void ValidaPosicaoDestiono(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroExption("Possicao de destino Invalida");
            }
        }
        private Cores Adversaria(Cores cor)
        {
            if (cor == Cores.Branca)
            {
                return Cores.Preta;
            }
            else
            {
                return Cores.Branca;
            }
        }
        private Peca Rei(Cores cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }
        public bool EstaEmXeque(Cores cor) // verifica se o rei esta em xeque 
        {
            Peca R = Rei(cor);

            if (R == null)
            {
                throw new TabuleiroExption($"Não exite rei da cor {cor} no tabuleiro");
            }
            foreach (Peca item in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = item.MovimentosPossieis();
                if (mat[R.posicao.Linha, R.posicao.Coluna] == true)
                {
                    return true; // esta em xeque se existe alguma peca adversaria com movimento possivel na casa do Rei 
                }
            }
            return false;
        }

        public bool TestaXequeMate(Cores cor)
        {
            if (!EstaEmXeque(cor)) //valida se o rei esta em xeque, se ele não esta, logo não é xequemate
            {
                return false;
            }
            foreach (Peca peca in PecasEmJogo(cor)) //verifica cada peça em jogo
            {
                bool[,] mat = peca.MovimentosPossieis(); //pega os mov possiveis dessa peça
                for (int i = 0; i < tab.linhas; i++)
                {
                    for (int j = 0; j < tab.colunas; j++)
                    {
                        if (mat[i, j] == true) //se existe movimento possivel para essa casa
                        {
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(peca.posicao, destino); //descolca a peça para a casa
                            bool testaXeque = EstaEmXeque(cor); //e valida se ainda está em xeque
                            DesfazMovimento(peca.posicao, destino, pecaCapturada);
                            if (!testaXeque) // se ele nao estiver em xeque depois disso , retorna falso, não esta em xequemate 
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true; // se nenhum movimento possivel rira o rei do xeque, xequeMate , perdeu o jogo
        }



    }
}
