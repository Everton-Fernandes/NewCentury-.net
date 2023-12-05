using System;
using System.Collections.Generic;
using System.Text;


namespace Exercicio_V
{
    public class HistoricoTentativas
    {
        public HistoricoTentativas()
        {
        }

        public HistoricoTentativas(
            int codJogador,
            int numTentativa,
            DateTime dataHoraTentativa,
            EnumResultado resultado)
        {
            this.CodJogador = codJogador;
            this.NumTentativa = numTentativa;
            this.DataHoraTentativa = dataHoraTentativa;
            this.Resultado = resultado;
        }

        public int CodJogador { get; set; }
        public int NumTentativa { get; set; }
        public DateTime DataHoraTentativa { get; set; }
        public EnumResultado Resultado { get; set; }
    }
}
