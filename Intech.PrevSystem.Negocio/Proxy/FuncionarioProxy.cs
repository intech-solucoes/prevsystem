using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class FuncionarioProxy : FuncionarioDAO
    {
        public FuncionarioEntidade BuscarPrimeiroPorCpf(string CPF)
        {
            var lista = base.BuscarPorCpf(CPF);

            return lista.OrderByDescending(x => x.DT_ADMISSAO).FirstOrDefault();
        }

        public FuncionarioDados BuscarDadosPorCodEntid(string COD_ENTID)
        {
            var funcionario = base.BuscarPorCodEntid(COD_ENTID);
            var entidade = new EntidadeProxy().BuscarPorCodEntid(COD_ENTID);
            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(COD_ENTID);
            var empresa = new EmpresaProxy().BuscarPorCodigo(funcionario.CD_EMPRESA);
            var estadoCivil = new EstadoCivilProxy().BuscarPorCodigo(dadosPessoais.CD_ESTADO_CIVIL);

            UsuarioEntidade usuario = null;

            try
            {
                usuario = new UsuarioProxy().BuscarPorCpf(entidade.CPF_CGC);
            } catch { }

            return new FuncionarioDados
            {
                Funcionario = funcionario,
                DadosPessoais = dadosPessoais,
                Entidade = entidade,
                Usuario = usuario,
                NOME_EMPRESA = empresa.NOME_ENTID,
                CNPJ_EMPRESA = empresa.CPF_CGC.AplicarMascara(Mascaras.CNPJ),
                CPF = dadosPessoais.CPF_CGC.AplicarMascara(Mascaras.CPF),
                SEXO = dadosPessoais.SEXO.Substring(0, 1).ToUpper() == "F" ? "FEMININO" : "MASCULINO",
                IDADE = dadosPessoais.DT_NASCIMENTO.IdadeEm(DateTime.Now).ToShortString(),
                DS_ESTADO_CIVIL = estadoCivil.DS_ESTADO_CIVIL,
                CEP = entidade.CEP_ENTID.AplicarMascara(Mascaras.CEP)
            };
        }
    }
}
