﻿using Tab;

namespace Tab {
    internal class Tabuleiro {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linha, int coluna) {

            Linhas = linha;
            Colunas = coluna;
            pecas = new Peca[linha, coluna];
        }

        public Peca peca(int linha, int coluna) {

            return pecas[linha, coluna];
        }

        public Peca peca(Posicao posicao) {

            return pecas[posicao.Linha, posicao.Coluna];
        }

        public Peca RetirarPeca(Posicao posicao) {

            if (peca(posicao) == null) {

                return null;
            }

            Peca aux = peca(posicao);
            aux.Posicao = null;
            pecas[posicao.Linha, posicao.Coluna] = null;

            return aux;
        }

        public bool ExistePeca(Posicao posicao) {

            ValidarPosicao(posicao);

            return peca(posicao) != null;
        }

        public bool PosicaoValida(Posicao posicao) {

            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas) {

                return false;
            }

            return true;
        }

        public void ColocarPeca(Peca peca, Posicao posicao) {

            if (ExistePeca(posicao)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }

            pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public void ValidarPosicao(Posicao posicao) {

            if (!PosicaoValida(posicao)) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
