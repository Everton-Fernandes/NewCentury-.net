namespace Exercicio_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o salário do colaborador: ");
            double salario = Convert.ToDouble(Console.ReadLine());

            double aumento = 0;
            if (salario <= 280)
                aumento = 0.2;
            else if (salario <= 700)
                aumento = 0.15;
            else if (salario <= 1500)
                aumento = 0.1;
            else
                aumento = 0.05;

            double valorAumento = salario * aumento;
            double novoSalario = salario + valorAumento;

            Console.WriteLine($"Salário antes do reajuste: {salario:C}");
            Console.WriteLine($"Percentual de aumento aplicado: {aumento * 100}%");
            Console.WriteLine($"Valor do aumento: {valorAumento:C}");
            Console.WriteLine($"Novo salário após o aumento: {novoSalario:C}");
            Console.ReadKey();
        }
    }
}