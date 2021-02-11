#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Metrus.Negocio
{
    public class DadosMetrusProxy
    {
        public dynamic BuscarPorCodEntid(string codEntid)
        {
            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            var entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

            EmpresaEntidade empresa;
            List<PlanoVinculadoEntidade> planos;

            if (funcionario != null)
            {
                empresa = new EmpresaProxy().BuscarPorCodigo(funcionario.CD_EMPRESA);
            }
            else
            {
                var recebedor = new RecebedorBeneficioProxy().BuscarPensionistaPorCpf(dadosPessoais.CPF_CGC.LimparMascara()).FirstOrDefault();
                funcionario = new FuncionarioProxy().BuscarPorMatriculaEmpresa(recebedor.NUM_MATRICULA, recebedor.CD_EMPRESA);
                empresa = new EmpresaProxy().BuscarPorCodigo(recebedor.CD_EMPRESA);
            }

            planos = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatricula(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA).ToList();

            if (dadosPessoais.CNT_ABERT_CRED == null)
                dadosPessoais.CNT_ABERT_CRED = "N";

            var dados = new
            {
                Status = true,
                NOME = funcionario.NOME_ENTID,
                CPF = dadosPessoais.CPF_CGC,
                empresa.CD_EMPRESA,
                DS_EMPRESA = empresa.NOME_ENTID,
                DadosPessoais = dadosPessoais,
                Funcionario = funcionario,
                Planos = planos,
                Entidade = entidade
            };

            return dados;
        }
    }
}
