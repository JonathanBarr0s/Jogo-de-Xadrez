using Tab;

namespace Xadrez {

    class Rainha : Peca {

        public Rainha(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "D";
        }

        private bool PodeMover(Posicao posicao) {
            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicoesParaMovimentar = new Posicao(0, 0);

            // esquerda
            posicoesParaMovimentar.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna - 1);
            }

            // direita
            posicoesParaMovimentar.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna + 1);
            }

            // acima
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha - 1, posicoesParaMovimentar.Coluna);
            }

            // abaixo
            posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha + 1, posicoesParaMovimentar.Coluna);
            }

            // NO
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha - 1, posicoesParaMovimentar.Coluna - 1);
            }

            // NE
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha - 1, posicoesParaMovimentar.Coluna + 1);
            }

            // SE
            posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha + 1, posicoesParaMovimentar.Coluna + 1);
            }

            // SO
            posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha + 1, posicoesParaMovimentar.Coluna - 1);
            }
            return movimentosPossiveis;
        }
    }
}