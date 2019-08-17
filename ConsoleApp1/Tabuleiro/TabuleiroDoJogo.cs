using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Game.Tabuleiro
{
    class TabuleiroDoJogo
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public TabuleiroDoJogo(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }
        public Peca RetornaPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public void ColocarPeca(Peca p, Posicao pos) //coloca uma peça se a posicao estiver valida 
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroExption("Já existe uma peça aqui");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }
        public Peca peca(Posicao pos) // retorna a peça na posicao informada 
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas) // delimita as bordas do tabuleiro
            {
                return false;
            }
            else { return true; }
               
        }
        public void ValidaPossicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroExption("Posição invalida!");
            }
        }
        public bool ExistePeca(Posicao pos)
        {
            ValidaPossicao(pos);
            return peca(pos) != null; // valida se a posicao existe e se existe peça na posicao informada 
        }
        public Peca RetirarPeca(Posicao pos) 
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
            
        }
    }
}
 