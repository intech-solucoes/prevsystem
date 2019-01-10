#region Usings
using DevExpress.XtraReports.UI;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Data;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Preves.API.Relatorios
{
    public partial class RelatorioExtratoContribuicao : XtraReport
    {
        DateTime DataInicio;
        DateTime DataFinal;
        DateTime DtInscPlano;
        DateTime UltimaDataConsulta;
        string NumMatricula;
        string AnoRefMesRefInicio;
        string AnoRefMesRefFim;
        string CdEmpresa;
        string CdPlano;
        string CdFundacao;
        const string NomePatrocinadora = "ESTADO DO ESPÍRITO SANTO";
        DateTime? _dtaUltimoIndice = null;

        FuncionarioEntidade Funcionario;
        FundacaoEntidade Fundacao;
        EmpresaEntidade Empresa;
        PlanoVinculadoEntidade Plano;

        public RelatorioExtratoContribuicao()
        {
            InitializeComponent();
        }

        public void GerarRelatorio(string cdFundacao, string cdEmpresa, string cdPlano, string numMatricula, DateTime dtaInicio, DateTime dtaFim)
        {
            CdEmpresa = cdEmpresa;
            CdPlano = cdPlano;
            CdFundacao = cdFundacao;
            DataInicio = dtaInicio;
            DataFinal = dtaFim;

            AnoRefMesRefInicio = dtaInicio.ToString("yyyyMM");
            AnoRefMesRefFim = dtaFim.ToString("yyyyMM");
            NumMatricula = numMatricula;

            Funcionario = new FuncionarioProxy().BuscarPorMatricula(numMatricula);

            PreencherCabecalhoDoRelatorio();

            PopularTabelaDoRelatorio();
        }

        private void PreencherCabecalhoDoRelatorio()
        {
            Fundacao = new FundacaoProxy().BuscarPorCodigo(CdFundacao);
            Empresa = new EmpresaProxy().BuscarPorCodigo(CdEmpresa);
            Plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CdFundacao, CdEmpresa, NumMatricula, CdPlano);

            xrLabelNomeFundacao.Text = Fundacao.NOME_ENTID;
            xrLabelEnderecoFundacao.Text = Fundacao.END_ENTID;
            xrLabelBairroFundacao.Text = Fundacao.BAIRRO_ENTID;
            xrTableCellCepFundacao.Text = $"CEP: {Fundacao.CEP_ENTID.AplicarMascara(Mascaras.CEP)}";
            xrTableCellEstadoFundacao.Text = $"ESTADO: {Fundacao.UF_ENTID}";
            xrTableCellTelefoneFundacao.Text = $"TEL: {Fundacao.FONE_ENTID}";
            xrTableCellFaxFundacao.Text = $"FAX: {Fundacao.FAX_ENTID}";
            xrTableCellCnpjFundacao.Text = $"CNPJ: {Fundacao.CPF_CGC.AplicarMascara(Mascaras.CNPJ)}";
            xrTableCellPeriodo.Text = $"Período: {DataInicio:MM/yyyy} à {DataFinal:MM/yyyy}";
            xrTableCellNomePatrocinadora.Text = NomePatrocinadora;
            xrTableCellVinculoInstitucional.Text = Empresa.NOME_ENTID;
            xrTableCellNomePlano.Text = Plano.DS_PLANO;
        }

        private void PopularTabelaDoRelatorio()
        {
            var relatorio = new FichaFechamentoPrevesProxy()
                .BuscarRelatorioPorFundacaoEmpresaPlanoInscricaoReferencia(CdFundacao, CdEmpresa, CdPlano, Funcionario.NUM_INSCRICAO, AnoRefMesRefInicio, AnoRefMesRefFim);
            
            foreach (var item in relatorio)
            {
                DataRow dr = TABLE_RELATORIO.NewRow();

                var anoCompetencia = Convert.ToInt32(item.ANO_COMP);
                var mesCompetencia = Convert.ToInt32(item.MES_COMP);

                dr["DT_INSC_PLANO"] = Plano.DT_INSC_PLANO;
                dr["DT_SITUACAO_EMPRESA"] = Funcionario.CD_SIT_EMPRESA == "04" ? Funcionario.DT_SITUACAO_EMPRESA?.ToString("dd/MM/yyyy") : "";
                dr["NOME_ENTID"] = Funcionario.NOME_ENTID;
                dr["NUM_MATRICULA"] = Funcionario.NUM_MATRICULA;
                dr["DS_LOTACAO"] = item.DS_LOTACAO;
                dr["COMPETENCIA"] = $"{mesCompetencia}/{anoCompetencia}";
                dr["IND_TIPO"] = item.IND_TIPO;
                dr["DT_FECHAMENTO"] = item.DT_FECHAMENTO;
                dr["VAL_CONTRIBUICAO_PARTICIPANTE"] = item.VL_GRUPO1;
                dr["VAL_CONTRIBUICAO_PATROCINADOR"] = item.VL_GRUPO2;
                dr["VAL_TAXA_CARREG"] = item.VL_GRUPO3;
                dr["VAL_BENEFICIO_RISCO"] = item.VL_GRUPO4;
                dr["VAL_SOBREVIVENCIA"] = item.VL_GRUPO5;
                dr["VAL_APOSENTADORIA_COMPLEMENTAR"] = item.VL_LIQUIDO;
                dr["VAL_COTA_CONVERSAO"] = item.VL_COTA;
                dr["QTDE_COTAS_SOBREVIVENCIA"] = item.QTE_COTA_SOBREV;
                dr["QTDE_COTAS_PREVIDENCIA"] = item.QTE_COTA;
                dr["QTDE_COTAS_ADIQUIRIDAS"] = item.QTE_COTA_ADIQ;
                dr["QTDE_COTAS_ACUMULADA"] = item.QTE_COTA_ACUM;
                dr["VALOR_ACUMULADO"] = item.VL_ACUMULADO;

                UltimaDataConsulta = new DateTime(anoCompetencia, mesCompetencia, new DateTime(anoCompetencia, mesCompetencia, 1).UltimoDiaDoMes().Day);

                TABLE_RELATORIO.Rows.Add(dr);
            }        
        }

        private void GroupFooter1_BeforePrint(object sender, EventArgs e)
        {
            decimal valCotaUltimaData = BuscarValorDaCotaNaUltimaData();

            xrTableCellUltimaData.Text = string.Format("{0:dd/MM/yyyy}", _dtaUltimoIndice);
            xrTableCellValCota.Text = string.Format("{0:N6}", valCotaUltimaData);
            xrTableCellSaldo.Text = string.Format("{0:N2}", valCotaUltimaData * Convert.ToDecimal(GetCurrentColumnValue("QTDE_COTAS_ACUMULADA")));
        }

        private decimal BuscarValorDaCotaNaUltimaData()
        {
            var empresaPlano = new EmpresaPlanosProxy().BuscarPorFundacaoEmpresaPlano(CdFundacao, CdEmpresa, CdPlano);
            var indice = new IndiceValoresProxy().BuscarUltimoPorCodigo(empresaPlano.IND_RESERVA_POUP);

            _dtaUltimoIndice = indice.First().DT_IND;
            return indice.First().VALOR_IND;
        }

        private void xrTableCellDataExoneracao_BeforePrint(object sender, EventArgs e)
        {

        }
    }
}
