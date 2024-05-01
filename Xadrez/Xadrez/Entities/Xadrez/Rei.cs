using Tab;

namespace Xadrez {
    internal class Rei : Peca {

        private PartidaDeXadrez Partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) {
            Partida = partida;
        }

        private bool PodeMover(Posicao posicao) {
            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        private bool TesteTorreParaRoque(Posicao posicao) {
            Peca peca = Tabuleiro.peca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QteMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicoesParaMovimentar = new Posicao(0, 0);

            //Acima
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
            }

            //Nordeste
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
            }

            //Direita
            posicoesParaMovimentar.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
            }

            //Sudeste
            posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
            }

            //Abaixo
            posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
            }

            //Sudoeste
            posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
            }

            //Esquerda
            posicoesParaMovimentar.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
            }

            //Noroeste
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
            }

            // Jogada Especial: Roque
            if (QteMovimentos == 0 && !Partida.Xeque) {

                // Jogada Especial: Roque Pequeno
                Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);

                if (TesteTorreParaRoque(posicaoTorre1)) {
                    Posicao peca1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao peca2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tabuleiro.peca(peca1) == null && Tabuleiro.peca(peca2) == null) {
                        movimentosPossiveis[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // Jogada Especial: Roque Grande
                Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);

                if (TesteTorreParaRoque(posicaoTorre2)) {
                    Posicao peca1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao peca2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao peca3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tabuleiro.peca(peca1) == null && Tabuleiro.peca(peca2) == null && Tabuleiro.peca(peca3) == null) {
                        movimentosPossiveis[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }
            return movimentosPossiveis;
        }

        public override string ToString() {
            return "R";
        }
    }
}
