using Tab;

namespace Xadrez {

    class Bispo : Peca {

        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }        

        private bool PodeMover(Posicao posicao) {

            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {

            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicoesParaMovimentar = new Posicao(0, 0);

            //Noroeste
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;

                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }

                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha - 1, posicoesParaMovimentar.Coluna - 1);
            }

            //Nordeste
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;

                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }

                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha - 1, posicoesParaMovimentar.Coluna + 1);
            }

            //Sudeste
            posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;

                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }

                posicoesParaMovimentar.DefinirValores(posicoesParaMovimentar.Linha + 1, posicoesParaMovimentar.Coluna + 1);
            }

            //Sudoeste
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

        public override string ToString() {
            return "B";
        }
    }
}