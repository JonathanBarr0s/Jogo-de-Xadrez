using Tab;

namespace Xadrez {
    internal class Program {
        static void Main(string[] args) {

            PosicaoXadrez posicao = new PosicaoXadrez('c', 7);

            Console.WriteLine(posicao);

            Console.WriteLine(posicao.ToPosicao());
        }
    }
}