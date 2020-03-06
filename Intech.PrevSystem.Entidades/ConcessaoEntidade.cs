using System;

namespace Intech.PrevSystem.Entidades
{
    public class ConcessaoEntidade
    {
        /// <summary>
        /// id do objeto
        /// </summary>
        public decimal Oid { get; set; }

        /// <summary>
        /// valor maximo definido na fundacao
        /// </summary>
        public decimal TetoMaximo { get; set; }

        /// <summary>
        /// valor maximo definido na fundacao menos os somatorios dos valores a reformar dos contratos ativos
        /// </summary>
        public decimal TetoMaximoCalculado { get; set; }

        /// <summary>
        /// valor minimo definido na fundacao
        /// </summary>
        public decimal TetoMinimo { get; set; }

        /// <summary>
        /// valor margem consignavel (prestacao maxima para o participante)
        /// </summary>
        public decimal MargemConsignavel { get; set; }

        /// <summary>
        /// taxa redutora definida pela fundacao
        /// </summary>
        public decimal TaxaMargemConsignavel { get; set; }

        /// <summary>
        /// valor prestacao maxima calculada MargemConsignavel x TaxaMargemConsignavel
        /// </summary>
        public decimal MargemConsignavelCalculada { get; set; }

        /// <summary>
        /// valor maximo do emprestimo: MargemConsignavel / fator 
        /// </summary>
        public decimal ValorMaximoEmprestimo { get; set; }

        /// <summary>
        /// valor solicitado digitado pelo usuario
        /// </summary>
        public decimal ValorSolicitado { get; set; }

        /// <summary>
        /// valor dos contratos selecionados para reformar
        /// </summary>
        public decimal ValorContratosReformados { get; set; }

        /// <summary>
        /// prazo maximo na natureza selecionada
        /// </summary>
        public decimal PrazoMaximo { get; set; }

        /// <summary>
        /// taxa de juros da concessao
        /// </summary>
        public decimal TaxaJuros { get; set; }

        /// <summary>
        /// armazena a taxa de juros antes do calculo do indice
        /// </summary>
        public decimal TaxaJurosOriginal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SSCA { get; set; }

        public decimal ValorReservaPoupanca { get; set; }

        public decimal TaxaRedutoraReservaPoupanca { get; set; }

        public string FlagDataConversaoRP { get; set; }

        public string TipoDataConversaoRP { get; set; }

        public string TipoDataConversaoRpAp { get; set; }//TP_DT_CONV_RP_AP

        public string TipoDataConversaoRpDf { get; set; }//TP_DT_CONV_RP_DF

        public DateTime DataSolicitacao { get; set; }

        public DateTime DataCredito { get; set; }

        /// <summary>
        /// se a natureza tiver percentual de desconto o mesmo vai estar nesse atributo.
        /// </summary>
        public decimal PercentualDesconto { get; set; }

        /// <summary>
        /// Valor Limite que a pessoa pode pegar
        /// </summary>
        public decimal ValorLimite { get; set; }

        public decimal ValorUltimoSalario { get; set; }

        public DadosEConsig DadosEConsig { get; set; }

    }
}
