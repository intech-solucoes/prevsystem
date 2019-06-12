using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Metrus.Negocio
{
    public class ParametrosSimuladorBeneficio
    {
        #region Constantes
        private const decimal Minimo = 0;
        private const decimal Basica1_Maximo = 2;
        private const decimal Basica2_Maximo = 3;
        private const decimal Basica3_Maximo = 7;
        private const decimal Suplementar_Maximo = 99.99M;
        #endregion

        #region Propriedades
        public Faixa Basica1 { get; set; }
        public Faixa Basica2 { get; set; }
        public Faixa Basica3 { get; set; }
        public Faixa Suplementar { get; set; }

        public decimal ValorSUC { get; set; }
        public decimal ValorSalario { get; set; }

        public decimal ValorTotalContribuicoesBasicas { get; set; }
        public decimal PercentualTotalContribuicoesBasicas { get; set; }
        #endregion

        public ParametrosSimuladorBeneficio(decimal valorSalario, decimal valorSUC)
        {
            Basica1 = new Faixa(Minimo, Basica1_Maximo);
            Basica2 = new Faixa(Minimo, Basica2_Maximo);
            Basica3 = new Faixa(Minimo, Basica3_Maximo);
            Suplementar = new Faixa(Minimo, Suplementar_Maximo);

            ValorSalario = valorSalario;
            ValorSUC = valorSUC;
            CarregarFaixas();
            Calcular();
        }

        private void CarregarFaixas()
        {
            Basica1.ValorDefinidoMinimo = 0.01M;
            Basica1.ValorDefinidoMaximo = 10 * ValorSUC;

            Basica2.ValorDefinidoMinimo = Basica1.ValorDefinidoMaximo + 0.01M;
            Basica2.ValorDefinidoMaximo = 20 * ValorSUC;

            Basica3.ValorDefinidoMinimo = Basica2.ValorDefinidoMaximo + 0.01M;
            Basica3.ValorDefinidoMaximo = decimal.MaxValue;

            Suplementar.ValorDefinidoMinimo = 0;
            Suplementar.ValorDefinidoMaximo = decimal.MaxValue;
        }

        private void Calcular()
        {
            Basica1.ValorResultante = ((Basica1.PercentualMaximo / 100) * Math.Min(ValorSalario, 10 * ValorSUC)).Arredonda(2);

            if ((10 * ValorSUC) < ValorSalario)
                Basica2.ValorResultante = ((Basica2.PercentualMaximo / 100) * Math.Min((ValorSalario - (10 * ValorSUC)), 10 * ValorSUC)).Arredonda(2);

            if ((20 * ValorSUC) < ValorSalario)
                Basica3.ValorResultante = ((Basica3.PercentualMaximo / 100) * (ValorSalario - (20 * ValorSUC))).Arredonda(2);

            Suplementar.ValorResultante = ((Suplementar.PercentualMaximo / 100) * ValorSalario).Arredonda(2);

            ValorTotalContribuicoesBasicas = Basica1.ValorResultante +
                                             Basica2.ValorResultante +
                                             Basica3.ValorResultante;

            if (ValorSalario != 0)
                PercentualTotalContribuicoesBasicas = ArredondaParaCima(Convert.ToDouble((ValorTotalContribuicoesBasicas / ValorSalario) * 100), 2);

            //A pedido da Norma, o valor máxima da básica deverá ser recalculado pelo percentual encontrado;
            ValorTotalContribuicoesBasicas = (ValorSalario * PercentualTotalContribuicoesBasicas / 100).Arredonda(2);

            PercentualTotalContribuicoesBasicas = PercentualTotalContribuicoesBasicas;

        }

        /// <summary>
        /// Arrendonda metade para cima.
        /// </summary>        
        public decimal ArredondaParaCima(double valor, int casaDecimais)
        {
            if ((Math.Abs(valor) - Math.Truncate(valor)) >= 0.500)
                return (decimal)Math.Round(Convert.ToDouble(valor + 0.00051), casaDecimais);

            return (decimal)Math.Round(Convert.ToDouble(valor), casaDecimais);
        }

    }

    public class Faixa
    {
        public decimal PercentualMinimo { get; set; }
        public decimal PercentualMaximo { get; set; }
        public decimal PercentualEscolhido { get; set; }
        public decimal ValorResultante { get; set; }
        public decimal ValorDefinidoMinimo { get; set; }
        public decimal ValorDefinidoMaximo { get; set; }

        public Faixa(decimal percentualMinimo, decimal percentualMaximo)
        {
            PercentualMinimo = percentualMinimo;
            PercentualMaximo = percentualMaximo;

            PercentualEscolhido = 0;
            ValorResultante = 0;
        }
    }
}
