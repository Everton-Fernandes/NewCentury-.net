using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_V
{
    public class JogoAdivinhacao
    {
        public JogoAdivinhacao(int totalTentativas)
        {
            this.TotalTentativas = totalTentativas;
            this.RestTentativas = totalTentativas;
            Random random = new Random();
            this.NumeroSecreto = random.Next(1, 101);
        }

        public int TotalTentativas { get; set; }

        public int RestTentativas { get; set; }

        public int Count { get; set; } = 0;

        public int NumeroSecreto { get; set; }


        public List<HistoricoTentativas> historicoTentativas = new List<HistoricoTentativas>();

        public string Menssagen { get; set; }

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

        public void Jogar(int jogadorEscolha, int valor)
        {
            int tentativa = valor;

            EnumResultado resultado = tentativa == NumeroSecreto ? EnumResultado.Acerto : EnumResultado.Erro;


            if (resultado == EnumResultado.Acerto)
            {
                this.Menssagen = $"Parabéns! Você acertou o número secreto {NumeroSecreto} na tentativa {Count}.";

                historicoTentativas.Add(new HistoricoTentativas
                {
                    CodJogador = jogadorEscolha,
                    NumTentativa = Count,
                    DataHoraTentativa = DateTime.Now,
                    Resultado = resultado
                });

                return;
            }
            else
            {
                if (Count < TotalTentativas)
                {
                    this.Menssagen = $"Tentativas restantes: {RestTentativas - 1} ";
                    Count++;
                    RestTentativas--;

                }
                else
                {
                    this.Menssagen = $"Você perdeu! Acabaram as tentativas.";
                    historicoTentativas.Add(new HistoricoTentativas
                    {
                        CodJogador = jogadorEscolha,
                        NumTentativa = Count,
                        DataHoraTentativa = DateTime.Now,
                        Resultado = resultado
                    });
                }
                return;
            }
        }
    }
}
