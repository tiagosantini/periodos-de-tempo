using System;

namespace Periodos.LibraryClass
{
    public class Periodo : PeriodoAuxLib
    {
        private DateTime data;
        private readonly string tempoDecorrido;
        private TimeSpan dataSubtraida;

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
                dataSubtraida = DateTime.Now.Subtract(data);
                return dataSubtraida.Days;
            }
        }

        private string TempoDecorridoPorExtenso()
        {
            string tempoPorExtenso = "";

            int diasNoMes = 30;

            if (DiasDecorridos < 1)
            {
                tempoPorExtenso = $"Hoje às {data.TimeOfDay}";
                tempoPorExtenso = tempoPorExtenso.Remove(tempoPorExtenso.Length - 3);
            }

            else if (DiasDecorridos < 7) // Dias
            {
                string medidaTempo = (DiasDecorridos == 1) ? "dia" : "dias";

                tempoPorExtenso = $"{numeros[DiasDecorridos]} {medidaTempo} atrás";
            }

            else if (DiasDecorridos < diasNoMes) // Semanas
            {
                int qtdSemanas = DiasDecorridos / 7;

                string strArtigo = (qtdSemanas == 1) ? "uma" : numeros[qtdSemanas];

                string medidaTempo = (qtdSemanas == 1) ? "semana" : "semanas";

                //int resto = DiasDecorridos % diasNoMes;

                //string diasSobrando = "";

                //if (resto != 0)
                //{
                //    string medidaTempoDias = (resto == 1) ? "dia" : "dias";
                //    diasSobrando = $" e {numeros[resto]} {medidaTempoDias}";
                //}

                tempoPorExtenso = $"{strArtigo} {medidaTempo} atrás";
            }

            else if (DiasDecorridos < 365) // Meses
            {
                string medidaTempo = (DiasDecorridos / diasNoMes == 1) ? "mês" : "meses";

                int resto = (DiasDecorridos % diasNoMes) / 7;

                string semanasSobrando = "";

                if (resto != 0)
                {
                    string strArtigo = (resto == 1) ? "uma" : numeros[resto];

                    string medidaTempoSemanas = (resto == 1) ? "semana" : "semanas";

                    semanasSobrando = $" e {strArtigo} {medidaTempoSemanas}";
                }
                
                tempoPorExtenso = $"{numeros[DiasDecorridos / diasNoMes]} {medidaTempo}{semanasSobrando} atrás";
            }

            else // Anos
            {
                string medidaTempo = (DiasDecorridos / 365 == 1) ? "ano" : "anos";

                tempoPorExtenso = $"{numeros[DiasDecorridos / 365]} {medidaTempo} atrás";
            }

            return tempoPorExtenso;
        }

        private void ValidarDataInserida(string data)
        {
            if (!DateTime.TryParse(data, out this.data))
                throw new ArgumentException("A data inserida é inválida!");
        }

    }
}