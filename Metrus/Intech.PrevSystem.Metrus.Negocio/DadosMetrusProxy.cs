#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Metrus.Negocio
{
    public class DadosMetrusProxy
    {
        public dynamic BuscarPorCodEntid(string codEntid)
        {
            var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
            var empresa = new EmpresaProxy().BuscarPorCodigo(funcionario.CD_EMPRESA);
            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            var planos = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatricula(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA).ToList();

            var dados = new
            {
                NOME = funcionario.NOME_ENTID,
                CPF = dadosPessoais.CPF_CGC,
                CD_EMPRESA = empresa.CD_EMPRESA,
                DS_EMPRESA = empresa.NOME_ENTID,
                DadosPessoais = dadosPessoais,
                Funcionario = funcionario,
                Planos = planos
            };

            return dados;
        }
    }
}
