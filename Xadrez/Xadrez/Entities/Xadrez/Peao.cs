using Tab;

namespace Xadrez {

    class Peao : Peca {

        private PartidaDeXadrez Partida;

        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) {

            Partida = partida;
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

                // Jogada Especial: En Passant

                if (Posicao.Linha == 3) {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);

                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.peca(esquerda) == Partida.VulneravelEnPassant) {
                        movimentosPossiveis[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.peca(direita) == Partida.VulneravelEnPassant) {
                        movimentosPossiveis[direita.Linha - 1, direita.Coluna] = true;
                    }
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

                // Jogada Especial: En Passant

                if (Posicao.Linha == 4) {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);

                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.peca(esquerda) == Partida.VulneravelEnPassant) {
                        movimentosPossiveis[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.peca(direita) == Partida.VulneravelEnPassant) {
                        movimentosPossiveis[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return movimentosPossiveis;
        }

        public override string ToString() {

            return "P";
        }
    }
}