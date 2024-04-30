using Tab;
using Xadrez;

namespace Jogo_de_Xadrez {
    internal class Program {
        static void Main(string[] args) {

            try {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] posicoesPossiveis = partida.Tabuleiro.peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }


            } catch (TabuleiroException exception) {

                Console.WriteLine(exception.Message);
            }
        }
    }
}