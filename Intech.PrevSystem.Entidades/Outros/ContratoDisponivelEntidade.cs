using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades.Outros
{
    public class ContratoDisponivelEntidade
    {
        public decimal Oid { get; set; }
        public string Fundacao { get; set; }
        public decimal Ano { get; set; }
        public decimal Numero { get; set; }
        public decimal SequenciaRubrica { get; set; }
        public decimal OidSituacaoContrato { get; set; }

        public string SituacaoContrato { get; set; }

        public decimal OidModalidade { get; set; }
        public ModalidadeEntidade Modalidade { get; set; }

        public decimal OidNatureza { get; set; }
        public NaturezaEntidade Natureza { get; set; }

        public DateTime DataCredito { get; set; }
        public DateTime DataCreditoAuxiliar { get; set; }
        public DateTime DataSolicitacao { get; set; }

        public decimal ValorSolicitado { get; set; }
        public decimal Prazo { get; set; }
        public decimal ValorJurosQuitacao { get; set; }
        public decimal ValorIOF { get; set; }
        public decimal ValorReformado { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal ValorSaldoQuitacao { get; set; }
        public decimal ValorCorrigido { get; set; }
        public decimal TaxaJuros { get; set; }
        public decimal ValorPrestacao { get; set; }
        public decimal ValorAReformar { get; set; }
        public decimal ValorAdministracao { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal ValorInadimplencia { get; set; }
        public decimal ValorRenov { get; set; }
        public decimal ValorAntecipacao { get; set; }
        public decimal NumeroGrupoFamiliar { get; set; }

        public List<PrestacaoEntidade> Prestacoes { get; set; }
        public List<PrestacaoParcialEntidade> PrestacoesParciais { get; set; }
        public SaldoDevedorEntidade SaldoDevedor { get; set; }

        public string CodigoPlano { get; set; }

        public bool PrestacoesMinimasPagas { get; set; }
        public decimal ValorAtualizacao { get; set; }
        public decimal ValorLimitePrestacao { get; set; }
        public decimal ValorLimiteParticipante { get; set; }
        public decimal Fator { get; set; }
        public DateTime DataVencimentoInicial { get; set; }
        public DateTime DataVencimentoFinal { get; set; }
        public DateTime DataVencimentoPrestacao { get; set; }
        public bool Disponivel { get; set; }
        public decimal TaxaJurosOriginal { get; set; }

        public string DescricaoDisponivel => Disponivel ? "Permitido" : "Não Permitido";

        public string Motivo { get; set; }
        public decimal ValorTaxaAdministracao { get; set; }
        public decimal ValorTaxaSeguro { get; set; }
        public decimal ValorTaxaSeguroEspecial { get; set; }
        public decimal ValorTaxaRenovacao { get; set; }
        public decimal ValorTaxaInadimplencia { get; set; }

        public DateTime DataInscricao { get; set; }
        public string FormaCredito { get; set; }
        public decimal Carencia { get; set; }
        public TaxaConcessaoPlanoEntidade TaxasConcessaoPlano { get; set; }
        public TaxasConcessaoEntidade TaxaConcessao { get; set; }
        public TaxaEncargoPlanoEntidade TaxasEncargoPlano { get; set; }
        public TaxasEncargosEntidade TaxaEncargo { get; set; }

        public ContratoDisponivelEntidade() { }

        public ContratoDisponivelEntidade(
              decimal Oid
            , decimal SequenciaRubrica
            , decimal PrazoDisponivel
            , decimal ValorSolicitado
            , decimal ValorAtualizacao
            , decimal ValorPrestacao
            , decimal ValorLimitePrestacao
            , decimal Fator
            , DateTime VencimentoInicial
            , DateTime VencimentoFinal
            , bool Disponivel
            , string Motivo
            , decimal ValorTaxaIOF
            , decimal ValorTaxaAdministracao
            , decimal ValorTaxaSeguro
            , decimal ValorTaxaSeguroEspecial
            , decimal ValorTaxaRenovacao
            , decimal ValorTaxaInadimplencia
            , decimal ValorLiquido
            , decimal TaxaJuros
            , decimal TaxaJurosOriginal
            , decimal Carencia
            )
        {
            this.Oid = Oid;
            this.SequenciaRubrica = SequenciaRubrica;
            this.Prazo = PrazoDisponivel;
            this.ValorSolicitado = ValorSolicitado;
            this.ValorAtualizacao = ValorAtualizacao;
            this.ValorPrestacao = ValorPrestacao;
            this.ValorLimitePrestacao = ValorLimitePrestacao;
            this.Fator = Fator;
            this.DataVencimentoInicial = VencimentoInicial;
            this.DataVencimentoFinal = VencimentoFinal;
            this.Disponivel = Disponivel;
            this.Motivo = Motivo;
            this.ValorIOF = ValorTaxaIOF;
            this.ValorTaxaAdministracao = ValorTaxaAdministracao;
            this.ValorTaxaSeguro = ValorTaxaSeguro;
            this.ValorTaxaSeguroEspecial = ValorTaxaSeguroEspecial;
            this.ValorTaxaRenovacao = ValorTaxaRenovacao;
            this.ValorTaxaInadimplencia = ValorTaxaInadimplencia;
            this.ValorLiquido = ValorLiquido;
            this.TaxaJuros = TaxaJuros;
            this.TaxaJurosOriginal = TaxaJurosOriginal;
            this.Carencia = Carencia;
        }
    }
}
