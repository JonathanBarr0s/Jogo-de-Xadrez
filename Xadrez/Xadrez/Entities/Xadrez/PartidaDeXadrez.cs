﻿using Tab;

namespace Xadrez {
    internal class PartidaDeXadrez {

        public Tabuleiro Tabuleiro { get; private set; }
        public Peca VulneravelEnPassant { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public int Turno { get; private set; }
        public bool Terminada { get; private set; }
        public bool Xeque { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;

        public PartidaDeXadrez() {

            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            VulneravelEnPassant = null;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();

            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino) {

            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMovimentos();

            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);

            if (pecaCapturada != null) {
                PecasCapturadas.Add(pecaCapturada);
            }

            // Jogada Especial: Roque Pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca Torre = Tabuleiro.RetirarPeca(origemTorre);

                Torre.IncrementarQuantidadeMovimentos();
                Tabuleiro.ColocarPeca(Torre, destinoTorre);
            }

            // Jogada Especial: Roque Grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2) {

                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca Torre = Tabuleiro.RetirarPeca(origemTorre);

                Torre.IncrementarQuantidadeMovimentos();
                Tabuleiro.ColocarPeca(Torre, destinoTorre);
            }

            // Jogada Especial: En Passant
            if (peca is Peao) {
                if (origem.Coluna != destino.Coluna && pecaCapturada == null) {
                    Posicao posicaoPeao;

                    if (peca.Cor == Cor.Branca) {
                        posicaoPeao = new Posicao(destino.Linha + 1, destino.Coluna);
                    } else {
                        posicaoPeao = new Posicao(destino.Linha - 1, destino.Coluna);
                    }

                    pecaCapturada = Tabuleiro.RetirarPeca(posicaoPeao);
                    PecasCapturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        private Peca Rei(Cor cor) {

            foreach (Peca item in PecasEmJogo(cor)) {
                if (item is Rei) {

                    return item;
                }
            }

            return null;
        }

        private Cor Adversaria(Cor cor) {

            if (cor == Cor.Branca) {

                return Cor.Preta;
            } else {

                return Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadasPorCor(Cor cor) {

            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in PecasCapturadas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {

            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in Pecas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PecasCapturadasPorCor(cor));

            return aux;
        }

        public bool EstaEmXeque(Cor cor) {

            Peca R = Rei(cor);

            if (R == null) {
                throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro!");
            }

            foreach (Peca item in PecasEmJogo(Adversaria(cor))) {
                bool[,] mat = item.MovimentosPossiveis();

                if (mat[R.Posicao.Linha, R.Posicao.Coluna]) {

                    return true;
                }
            }

            return false;
        }

        public bool TesteXequemate(Cor cor) {

            if (!EstaEmXeque(cor)) {

                return false;
            }

            foreach (Peca item in PecasEmJogo(cor)) {
                bool[,] mat = item.MovimentosPossiveis();

                for (int i = 0; i < Tabuleiro.Linhas; i++) {
                    for (int j = 0; j < Tabuleiro.Colunas; j++) {

                        if (mat[i, j]) {
                            Posicao origem = item.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);

                            DesfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque) {

                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {

            Peca peca = Tabuleiro.RetirarPeca(destino);
            peca.DecrementarQuantidadeMovimentos();

            if (pecaCapturada != null) {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }

            Tabuleiro.ColocarPeca(peca, origem);

            // Jogada Especial: Roque Pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca Torre = Tabuleiro.RetirarPeca(destinoTorre);

                Torre.DecrementarQuantidadeMovimentos();
                Tabuleiro.ColocarPeca(Torre, origemTorre);
            }

            // Jogada Especial: Roque Grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca Torre = Tabuleiro.RetirarPeca(destinoTorre);

                Torre.DecrementarQuantidadeMovimentos();
                Tabuleiro.ColocarPeca(Torre, origemTorre);
            }

            // Jogada Especial: En Passant
            if (peca is Peao) {
                if (origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant) {
                    Peca peao = Tabuleiro.RetirarPeca(destino);
                    Posicao posicaoPeao;

                    if (peca.Cor == Cor.Branca) {
                        posicaoPeao = new Posicao(3, destino.Coluna);
                    } else {
                        posicaoPeao = new Posicao(4, destino.Coluna);
                    }

                    Tabuleiro.ColocarPeca(peao, posicaoPeao);
                }
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }

            Peca peca = Tabuleiro.peca(destino);

            // Jogada Especial: Promocao
            if (peca is Peao) {
                if ((peca.Cor == Cor.Branca && destino.Linha == 0) || (peca.Cor == Cor.Preta && destino.Linha == 7)) {
                    peca = Tabuleiro.RetirarPeca(destino);
                    Pecas.Remove(peca);

                    Peca rainha = new Rainha(Tabuleiro, peca.Cor);
                    Tabuleiro.ColocarPeca(rainha, destino);

                    Pecas.Add(rainha);
                }
            }

            if (EstaEmXeque(Adversaria(JogadorAtual))) {
                Xeque = true;
            } else {
                Xeque = false;
            }

            if (TesteXequemate(Adversaria(JogadorAtual))) {
                Terminada = true;
            } else {
                Turno++;
                MudaJogador();
            }

            // Jogada Especial: En Passant
            if (peca is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2)) {
                VulneravelEnPassant = peca;
            } else {
                VulneravelEnPassant = null;
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao posicao) {

            if (Tabuleiro.peca(posicao) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if (JogadorAtual != Tabuleiro.peca(posicao).Cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if (!Tabuleiro.peca(posicao).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino) {

            if (!Tabuleiro.peca(origem).MovimentoPossivel(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {

            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void MudaJogador() {

            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            } else {
                JogadorAtual = Cor.Branca;
            }
        }

        private void ColocarPecas() {

            ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rainha(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rainha(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preta, this));
        }
    }
}
