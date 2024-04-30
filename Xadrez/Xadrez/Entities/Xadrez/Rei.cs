using Tab;

namespace Xadrez {
    internal class Rei : Peca {

        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
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
            return movimentosPossiveis;
        }

        public override string ToString() {
            return "R";
        }
    }
}
