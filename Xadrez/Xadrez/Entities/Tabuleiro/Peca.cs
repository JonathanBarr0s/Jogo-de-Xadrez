namespace Tab
{
    internal abstract class Peca
    {

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Tabuleiro = tabuleiro;
            Cor = cor;
        }

        public abstract bool[,] MovimentosPossiveis();

        public void IncrementarQuantidadeMovimentos() {
            QteMovimentos++;
        }
    }
}
