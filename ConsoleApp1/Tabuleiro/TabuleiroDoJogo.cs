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
        public Peca retornaPeca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public void colocarPeca(Peca p, Posicao pos) //coloca uma peça se a posicao estiver valida 
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça aqui");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }
        public Peca peca(Posicao pos) // retorna a peça na posicao informada 
        {
            return pecas[pos.linha, pos.coluna];
        }
        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas) // delimita as bordas do tabuleiro
            {
                return false;
            }
            else { return true; }
               
        }
        public void validaPossicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição invalida!");
            }
        }
        public bool existePeca(Posicao pos)
        {
            validaPossicao(pos);
            return peca(pos) != null; // valida se a posicao existe e se existe peça na posicao informada 
        }
        public Peca retirarPeca(Posicao pos) 
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
            
        }
    }
}
 