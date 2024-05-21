using System.Runtime.Intrinsics.X86;
using Tab;
using Xadrez;

namespace Jogo_de_Xadrez {
    internal class Tela {

        public static PosicaoXadrez LerPosicaoXadrez() {

            string jogada = Console.ReadLine().ToLower();
            char coluna = jogada[0];
            int linha = int.Parse(jogada[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPartida(PartidaDeXadrez partida) {

            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();

            ImprimirPecasCapturadas(partida);
            Console.WriteLine();

            Console.WriteLine($"Turno: {partida.Turno}");

            if (!partida.Terminada) {
                Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");

                if (partida.Xeque) {
                    Console.WriteLine();
                    Console.WriteLine("XEQUE!");
                }
            } else {
                Console.WriteLine();
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine($"Vencedor: {partida.JogadorAtual}");
            }
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {

            Console.WriteLine("Peças capturadas:");

            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadasPorCor(Cor.Branca));
            Console.WriteLine();

            Console.Write("Vermelhas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            ImprimirConjunto(partida.PecasCapturadasPorCor(Cor.Preta));

            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto) {

            Console.Write("[");

            foreach (var item in conjunto) {
                Console.Write(item + " ");
            }

            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;

            for (int i = 0; i < tabuleiro.Linhas; i++) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux;

                for (int j = 0; j < tabuleiro.Colunas; j++) {
                    ImprimirPeca(tabuleiro.peca(i, j));
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux;

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            ConsoleColor aux = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;

            for (int i = 0; i < tabuleiro.Linhas; i++) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux;

                for (int j = 0; j < tabuleiro.Colunas; j++) {

                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimirPeca(tabuleiro.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux;

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;
            Console.BackgroundColor = fundoOriginal;
        }

        public static void ImprimirPeca(Peca peca) {

            if (peca == null) {
                Console.Write("· ");
            } else {

                if (peca.Cor == Cor.Branca) {
                    Console.Write(peca);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
        }
    }
}