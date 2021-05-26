using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Periodos.LibraryClass
{
    public class Periodo
    {
        private DateTime data;
        private readonly string tempoDecorrido;

        string[] unidades = new[] { "zero", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };

        public Periodo(string data)
        {
            ValidarDataInserida(data);
            tempoDecorrido = TempoDecorridoPorExtenso();
        }

        public string TempoDecorrido
        {
            get => PrimeiraLetraMaiuscula(tempoDecorrido);
        }

        private int DiasDecorridos
        {
            get
            {
                TimeSpan dataSubtraida = DateTime.Now.Subtract(data);

                return dataSubtraida.Days;
            }
        }

        private string TempoDecorridoPorExtenso()
        {
            string tempoPorExtenso = "";

            TimeSpan dataSubtraida = DateTime.Now.Subtract(data);

            int diasNoMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            if (DiasDecorridos < 7) // Dias
            {
                string sufixo = (DiasDecorridos == 1) ? "dia" : "dias";

                tempoPorExtenso = $"{unidades[DiasDecorridos]} {sufixo} atrás";
            }

            else if (DiasDecorridos < diasNoMes) // Semanas
            {
                int qtdSemanas = DiasDecorridos / 7;

                string prefixo = (qtdSemanas == 1) ? "uma" : unidades[qtdSemanas];

                string sufixo = (qtdSemanas == 1) ? "semana" : "semanas";

                tempoPorExtenso = $"{prefixo} {sufixo} atrás";
            }

            else if (DiasDecorridos < 365) // Meses
            {
                string sufixo = (DiasDecorridos / diasNoMes == 1) ? "mes" : "meses";

                tempoPorExtenso = $"{unidades[DiasDecorridos / diasNoMes]} {sufixo} atrás";
            }

            else // Anos
            {
                string sufixo = (DiasDecorridos / 365 == 1) ? "ano" : "anos";

                tempoPorExtenso = $"{unidades[DiasDecorridos / 365]} {sufixo} atrás";
            }

            return tempoPorExtenso;
        }

        //private string DefinirExtensaoDeData()
        //{
        //    tempo
        //}

        private void ValidarDataInserida(string data)
        {
            if(!DateTime.TryParse(data, out this.data))
                throw new ArgumentException("A data inserida é inválida!");
        }

        private string PrimeiraLetraMaiuscula(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
