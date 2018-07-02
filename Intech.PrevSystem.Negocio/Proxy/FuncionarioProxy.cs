using Intech.PrevSystem.Dados.DAO;
using System;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class FuncionarioProxy : FuncionarioDAO
    {
        public dynamic BuscarDadosPorCodEntid(string COD_ENTID)
        {
            var funcionario = base.BuscarPorCodEntid(COD_ENTID);
            var entidade = new EntidadeProxy().BuscarPorCodEntid(COD_ENTID);
            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(COD_ENTID);
            var empresa = new EmpresaProxy().BuscarPorCodigo(funcionario.CD_EMPRESA);
            var estadoCivil = new EstadoCivilProxy().BuscarPorCodigo(dadosPessoais.CD_ESTADO_CIVIL);

            return new
            {
                funcionario,
                dadosPessoais,
                entidade,
                NOME_EMPRESA = empresa.NOME_ENTID,
                CPF = dadosPessoais.CPF_CGC.AplicarMascara(Mascaras.CPF),
                SEXO = dadosPessoais.SEXO.Substring(0, 1).ToUpper() == "F" ? "FEMININO" : "MASCULINO",
                IDADE = dadosPessoais.DT_NASCIMENTO.IdadeEm(DateTime.Now).ToShortString(),
                estadoCivil.DS_ESTADO_CIVIL,
                CEP = entidade.CEP_ENTID.AplicarMascara(Mascaras.CEP)
            };
        }
    }
}
