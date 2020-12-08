using Intech.Lib.Util.Date;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades.Outros
{
    public class SaldoEntidade
    {
        private decimal _taxa;

        /// <summary>
        /// Taxa de reajuste aplicada
        /// </summary>
        public decimal Taxa
        {
            get { return _taxa; }
            set { _taxa = value.Arredonda(2); }
        }

        private decimal _fundoIndividual;

        public decimal FundoIndividual
        {
            get { return _fundoIndividual; }
            set { _fundoIndividual = value.Arredonda(2); }
        }

        private decimal _fundoPatronal;

        public decimal FundoPatronal
        {
            get { return _fundoPatronal; }
            set { _fundoPatronal = value.Arredonda(2); }
        }

        private decimal _fundoTransferencia;

        public decimal FundoTransferencia
        {
            get { return _fundoTransferencia; }
            set { _fundoTransferencia = value.Arredonda(2); }
        }

        private decimal _fundoCompResMatematica;

        public decimal FundoCompResMatematica
        {
            get { return _fundoCompResMatematica; }
            set { _fundoCompResMatematica = value.Arredonda(2); }
        }

        private decimal _fundoResPoupancaMigracao;

        public decimal FundoResPoupancaMigracao
        {
            get { return _fundoResPoupancaMigracao; }
            set { _fundoResPoupancaMigracao = value.Arredonda(2); }
        }

        private decimal _fundoIndividualPortado;

        public decimal FundoIndividualPortado
        {
            get { return _fundoIndividualPortado; }
            set { _fundoIndividualPortado = value.Arredonda(2); }
        }


        /// <summary>
        /// Saldo total 
        /// </summary>
        public decimal Total
        {
            get { return FundoIndividual + FundoPatronal + FundoTransferencia + FundoCompResMatematica + FundoResPoupancaMigracao + FundoIndividualPortado; }
        }

        /// <summary>
        /// 99,99% do saldo total à vista
        /// </summary>
        public decimal TotalVista
        {
            get { return Total * (PercentualVista / 100); }
        }

        public decimal TotalSemAdiantamento
        {
            get { return Total - TotalVista; }
        }

        /// <summary>
        /// Data do saldo
        /// </summary>
        public MesAno Data { get; set; }

        private decimal _percentualVista;

        /// <summary>
        /// Percentual da Parcela do Saldo de contribuição à vista
        /// </summary>
        public decimal PercentualVista
        {
            get { return _percentualVista; }
            set { _percentualVista = value; }
        }
    }
}
