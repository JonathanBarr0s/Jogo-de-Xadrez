using Tab;

namespace Xadrez {
    internal class Torre : Peca {

        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        private bool PodeMover(Posicao posicao) {
            Peca peca = Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicoesParaMovimentar = new Posicao(0, 0);

            //Acima
            posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.Linha = posicoesParaMovimentar.Linha - 1;
            }

            //Abaixo
            posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.Linha = posicoesParaMovimentar.Linha + 1;
            }

            //Direita
            posicoesParaMovimentar.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.Coluna = posicoesParaMovimentar.Coluna + 1;
            }

            //Esquerda
            posicoesParaMovimentar.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && PodeMover(posicoesParaMovimentar)) {
                movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                if (Tabuleiro.peca(posicoesParaMovimentar) != null && Tabuleiro.peca(posicoesParaMovimentar).Cor != Cor) {
                    break;
                }
                posicoesParaMovimentar.Coluna = posicoesParaMovimentar.Coluna - 1;
            }
            return movimentosPossiveis;
        }

        public override string ToString() {
            return "T";
        }
    }
}
