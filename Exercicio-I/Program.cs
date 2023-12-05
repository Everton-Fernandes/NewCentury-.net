namespace Exercicio_I
{
    using System;
    using System.Collections.Generic;

    public enum Resultado
    {
        Acerto,
        Erro
    }

    public class HistoricoTentativa
    {
        public int CodJogador { get; set; }
        public int NumTentativa { get; set; }
        public DateTime DataHoraTentativa { get; set; }
        public Resultado Resultado { get; set; }
    }

    public class JogoAdivinhacao
    {
        private List<HistoricoTentativa> historicoTentativas = new List<HistoricoTentativa>();
        private int totalTentativas;

        public JogoAdivinhacao(int totalTentativas)
        {
            this.totalTentativas = totalTentativas;
        }

        public Dictionary<string, int> ObterDificuldadeETentativas()
        {
            Dictionary<string, int> dificuldadeETentativas = new Dictionary<string, int>
        {
            { "Fácil", 10 },
            { "Médio", 7 },
            { "Difícil", 5 }
        };

            return dificuldadeETentativas;
        }

        public void MostrarHistorico()
        {
            Console.WriteLine("Historico de Tentativas:");
            foreach (var tentativa in historicoTentativas)
            {
                Console.WriteLine($"Jogador: {tentativa.CodJogador}, Tentativa: {tentativa.NumTentativa}, " +
                                  $"Data e Hora: {tentativa.DataHoraTentativa}, Resultado: {tentativa.Resultado}");
            }
        }

        public void Jogar(int jogadorEscolha)
        {
            Random random = new Random();
            int numeroSecreto = random.Next(1, 101);

            Console.WriteLine($"Jogador {jogadorEscolha}, você tem {totalTentativas} tentativas para adivinhar o número entre 1 e 100.");

            for (int i = 1; i <= totalTentativas; i++)
            {
                Console.Write("Digite sua tentativa: ");
                int tentativa = Convert.ToInt32(Console.ReadLine());

                Resultado resultado = tentativa == numeroSecreto ? Resultado.Acerto : Resultado.Erro;

                historicoTentativas.Add(new HistoricoTentativa
                {
                    CodJogador = jogadorEscolha,
                    NumTentativa = i,
                    DataHoraTentativa = DateTime.Now,
                    Resultado = resultado
                });

                if (resultado == Resultado.Acerto)
                {
                    Console.WriteLine($"Parabéns! Você acertou o número secreto {numeroSecreto} na tentativa {i}.");
                    break;
                }
                else
                {
                    Console.WriteLine("Tente novamente.");
                    if (i < totalTentativas)
                        Console.WriteLine($"Tentativas restantes: {totalTentativas - i}");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Digite o nome do jogador: ");
            string nomeJogador = Console.ReadLine();

            Console.WriteLine($"Bem-vindo, {nomeJogador}!");

            JogoAdivinhacao jogo = new JogoAdivinhacao(7);

            Dictionary<string, int> dificuldadeETentativas = jogo.ObterDificuldadeETentativas();

            Console.WriteLine("Escolha a dificuldade:");
            foreach (var kvp in dificuldadeETentativas)
            {
                Console.WriteLine($"{kvp.Key} - Tentativas: {kvp.Value}");
            }

            Console.Write("Digite a opção desejada: ");
            string escolhaDificuldade = Console.ReadLine();

            if (dificuldadeETentativas.TryGetValue(escolhaDificuldade, out int tentativas))
            {
                jogo.Jogar(1); // Jogador humano

                Console.WriteLine("Histórico do Jogador:");
                jogo.MostrarHistorico();
            }
            else
            {
                Console.WriteLine("Opção de dificuldade inválida.");
                Console.ReadKey();
            }
        }
    }
}