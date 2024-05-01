using Tab;

namespace Xadrez {

    class Peao : Peca {

        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "P";
        }

        private bool ExisteInimigo(Posicao posicao) {
            Peca peca = Tabuleiro.peca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao posicao) {
            return Tabuleiro.peca(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicoesParaMovimentar = new Posicao(0, 0);

            if (Cor == Cor.Branca) {
                posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && Livre(posicoesParaMovimentar)) {
                    movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                }
                posicoesParaMovimentar.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && Livre(p2) && Tabuleiro.PosicaoValida(posicoesParaMovimentar) && Livre(posicoesParaMovimentar) && QteMovimentos == 0) {
                    movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                }
                posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && ExisteInimigo(posicoesParaMovimentar)) {
                    movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                }
                posicoesParaMovimentar.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && ExisteInimigo(posicoesParaMovimentar)) {
                    movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                }
            } else {
                posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && Livre(posicoesParaMovimentar)) {
                    movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                }
                posicoesParaMovimentar.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && Livre(p2) && Tabuleiro.PosicaoValida(posicoesParaMovimentar) && Livre(posicoesParaMovimentar) && QteMovimentos == 0) {
                    movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                }
                posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && ExisteInimigo(posicoesParaMovimentar)) {
                    movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                }
                posicoesParaMovimentar.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicoesParaMovimentar) && ExisteInimigo(posicoesParaMovimentar)) {
                    movimentosPossiveis[posicoesParaMovimentar.Linha, posicoesParaMovimentar.Coluna] = true;
                }
            }
            return movimentosPossiveis;
        }
    }
}