namespace Exercicio_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] opcoes = { "Windows Server", "Unix", "Linux", "Netware", "Mac OS", "Outro" };
            int[] votos = new int[opcoes.Length];

            int voto;
            do
            {
                Console.WriteLine("Qual o melhor Sistema Operacional para uso em servidores?");
                for (int i = 0; i < opcoes.Length; i++)
                    Console.WriteLine($"{i + 1} - {opcoes[i]}");

                Console.Write("Digite o número da sua escolha (ou 0 para encerrar): ");
                voto = Convert.ToInt32(Console.ReadLine());

                if (voto >= 1 && voto <= opcoes.Length)
                    votos[voto - 1]++;
                else if (voto != 0)
                    Console.WriteLine("Opção inválida. Tente novamente.");

            } while (voto != 0);

            Console.WriteLine("Sistema Operacional     Votos     %");
            Console.WriteLine("-----------------------------------");

            int totalVotos = 0;
            for (int i = 0; i < opcoes.Length; i++)
                totalVotos += votos[i];

            for (int i = 0; i < opcoes.Length; i++)
            {
                double percentual = (double)votos[i] / totalVotos * 100;
                Console.WriteLine($"{opcoes[i],-21} {votos[i],-9} {percentual:F}%");
            }

            int indiceVencedor = Array.IndexOf(votos, votos.Max());
            Console.WriteLine($"\nO Sistema Operacional mais votado foi o {opcoes[indiceVencedor]}, com {votos[indiceVencedor]} votos, correspondendo a {(double)votos[indiceVencedor] / totalVotos * 100}% dos votos.");
            Console.ReadKey();
        }
    }
}