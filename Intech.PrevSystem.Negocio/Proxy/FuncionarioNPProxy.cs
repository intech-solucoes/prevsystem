using Intech.Lib.Util.Date;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FuncionarioNPProxy : FuncionarioNPDAO
	{
		public FuncionarioNPProxy (IDbTransaction tx = null) : base(tx) { }

        public FuncionarioNPDados BuscarDadosNaoParticipantePorMatriculaEmpresa(string Matricula, string cdEmpresa)
        {
            var funcionario = new FuncionarioNPDados();

            funcionario.Funcionario = new FuncionarioNPProxy().BuscarPorMatricula(Matricula).FirstOrDefault();
            //funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(cdEmpresa);
            //funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.Usuario = new UsuarioProxy().BuscarPorCpf(funcionario.Funcionario.CPF_CGC);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.Funcionario.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;
            funcionario.NOME_EMPRESA = funcionario.Empresa.NOME_ENTID;
            funcionario.IDADE = new Intervalo(DateTime.Now, funcionario.Funcionario.DT_NASCIMENTO.Value, new CalculoAnosMesesDiasAlgoritmo2()).Anos.ToString() + " anos";
            funcionario.SEXO = funcionario.Funcionario.SEXO == "M" ? "MASCULINO" : "FEMININO";

            return funcionario;
        }
    }
}
