namespace Exercicio_IV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o tipo de carne (File Duplo, Alcatra, Picanha): ");
            string tipoCarne = Console.ReadLine();

            Console.Write("Digite a quantidade em Kg: ");
            double quantidade = Convert.ToDouble(Console.ReadLine());

            Console.Write("A compra será feita no cartão Tabajara? (S para sim, N para não): ");
            char pagamentoCartao = Console.ReadLine()[0];

            double precoKg;
            switch (tipoCarne.ToLower())
            {
                case "file duplo":
                    precoKg = quantidade <= 5 ? 4.9 : 5.8;
                    break;
                case "alcatra":
                    precoKg = quantidade <= 5 ? 5.9 : 6.8;
                    break;
                case "picanha":
                    precoKg = quantidade <= 5 ? 6.9 : 7.8;
                    break;
                default:
                    Console.WriteLine("Tipo de carne inválido.");
                    return;
            }

            double precoTotal = quantidade * precoKg;

            if (pagamentoCartao == 's' || pagamentoCartao == 'S')
                precoTotal *= 0.95; // Desconto de 5% para pagamento no cartão Tabajara

            Console.WriteLine("\nCupom Fiscal");
            Console.WriteLine($"Tipo de carne: {tipoCarne}");
            Console.WriteLine($"Quantidade: {quantidade} Kg");
            Console.WriteLine($"Preço total: {precoTotal:C}");
            Console.WriteLine($"Tipo de pagamento: {(pagamentoCartao == 's' || pagamentoCartao == 'S' ? "Cartão Tabajara" : "Outro")}");
            Console.WriteLine($"Desconto: {(pagamentoCartao == 's' || pagamentoCartao == 'S' ? "5%" : "0%")}");
            Console.WriteLine($"Valor a pagar: {precoTotal:C}");
            Console.ReadKey();
        }
    }
}