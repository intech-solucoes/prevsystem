using System;

namespace Intech.PrevSystem.Entidades
{
    public class SaldoDevedorEntidade
    {
        public DateTime DataQuitacao { get; set; }

        public decimal Prazo { get; set; }

        public decimal ValorPrincQuitacao { get; set; }

        public decimal ValorJurosQuitacao { get; set; }

        public decimal ValorSeguroQuit { get; set; }

        public decimal ValorPrestMes { get; set; }

        public decimal ValorPrincPrestMes { get; set; }

        public decimal ValorJurosPrestMes { get; set; }

        public decimal ValorSeguroProrata { get; set; }

        public decimal ValorPrestAtraso { get; set; }

        public decimal ValorPrincPrestAtraso { get; set; }

        public decimal ValorJurosPrestAtraso { get; set; }

        public decimal ValorTxSeguroQuitacao { get; set; }

        public decimal ValorCorrPrestAtraso { get; set; }

        public decimal ValorJurosMoraPrest { get; set; }

        public decimal ValorMultaPrest { get; set; }

        public decimal ValorCorrecaoSaldoQuitacao { get; set; }

        public decimal ValorDescQuitacao { get; set; }

        public decimal ValorDescSeguro { get; set; }

        public decimal ValorDescSeguroEsp { get; set; }

        public decimal ValorTxAdmMesQuit { get; set; }

        public decimal ValorTxAdmQuit { get; set; }

        public decimal ValorReformado { get; set; }

        public decimal ValorCorrPrincPrestMes { get; set; }

        public decimal ValorCorrJurosPrestMes { get; set; }

        public decimal PrevRec { get; set; }

        public decimal PrevRecMes { get; set; }

        public decimal ValorIOFcompl { get; set; }

        public decimal ValorSeguroAdmAcrescimo { get; set; }
    }
}
