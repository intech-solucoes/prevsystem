#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Data; 
#endregion

namespace Intech.PrevSystem.Preves.API.Relatorios
{
    public partial class CertificadoDeRegistroNoPlano : DevExpress.XtraReports.UI.XtraReport
    {
        public CertificadoDeRegistroNoPlano()
        {
            InitializeComponent();
        }

        public void GerarRelatorio(string cdMatricula, string cdPlano, string cdEmpresa)
        {
            var funcionario = new FuncionarioProxy().BuscarPorMatriculaEmpresa(cdMatricula, cdEmpresa);
            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(funcionario.COD_ENTID.ToString());
            var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, cdPlano);

            DataRow dr = TABLE_RELATORIO.NewRow();

            dr["NOM_PARTICIPANTE"] = funcionario.NOME_ENTID;
            dr["COD_CPF"] = dadosPessoais.CPF_CGC.AplicarMascara(Mascaras.CPF);
            dr["NOM_PLANO"] = plano.DS_PLANO;
            dr["COD_CNPB"] = plano.COD_CNPB;
            dr["NUM_INSCRICAO"] = funcionario.NUM_INSCRICAO;
            dr["DTA_REGISTRO"] = plano.DT_INSC_PLANO.ToString("dd/MM/yyyy");

            TABLE_RELATORIO.Rows.Add(dr);
        }
    }
}
