namespace Exercicio_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> vendasBrutas = new List<double> { 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };

            int[] contadores = new int[10]; // Índices 0-8 representam intervalos de $200, índice 9 representa $1000 ou mais

            foreach (double vendaBruta in vendasBrutas)
            {
                double salario = 200 + 0.09 * vendaBruta;

                int indice = (int)(salario / 100) - 2;
                if (indice >= 0 && indice <= 8)
                    contadores[indice]++;
                else
                    contadores[9]++;
            }

            for (int i = 0; i <= 8; i++)
                Console.WriteLine($"Entre ${(200 + i * 100)} e ${(299 + i * 100)}: {contadores[i]} vendedores");

            Console.WriteLine($"$1000 e mais: {contadores[9]} vendedores");
            Console.ReadKey();
        }
    }
}