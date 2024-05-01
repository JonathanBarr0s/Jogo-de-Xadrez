namespace Tab {
    internal abstract class Peca {

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            Tabuleiro = tabuleiro;
            Cor = cor;
        }

        public abstract bool[,] MovimentosPossiveis();

        public void IncrementarQuantidadeMovimentos() {
            QteMovimentos++;
        }
        
        public void DecrementarQuantidadeMovimentos() {
            QteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] existeMovimentosPossiveis = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++) {
                for (int j = 0; j < Tabuleiro.Colunas; j++) {
                    if (existeMovimentosPossiveis[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao posicao) {
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }
    }
}
