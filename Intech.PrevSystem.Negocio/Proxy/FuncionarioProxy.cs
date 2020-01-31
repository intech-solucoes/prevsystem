using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class FuncionarioProxy : FuncionarioDAO
    {
        public FuncionarioDados BuscarDadosPorCodEntid(string codEntid)
        {
            var funcionario = new FuncionarioDados();

            funcionario.Funcionario = base.BuscarPorCodEntid(codEntid);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(funcionario.Funcionario.CD_EMPRESA);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;

            return funcionario;
        }

        public FuncionarioDados BuscarDadosPorCodEntidEmpresa(string codEntid, string cdEmpresa)
        {
            var funcionario = new FuncionarioDados();

            funcionario.Funcionario = base.BuscarPorCodEntid(codEntid);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(cdEmpresa);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;

            return funcionario;
        }

        public FuncionarioDados BuscarDadosPorCodEntidEmpresaLogin(string codEntid, string cdEmpresa, string NomLogin)
        {
            var funcionario = new FuncionarioDados();

            funcionario.Funcionario = base.BuscarPorCodEntid(codEntid);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(cdEmpresa);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.Usuario = new UsuarioProxy().BuscarPorCpf(NomLogin);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;

            return funcionario;
        }

        public FuncionarioDados BuscarDadosPorCodEntidEmpresa(string codEntid, string codEntidFuncionario, string cdEmpresa)
        {
            var funcionario = new FuncionarioDados();

            funcionario.Funcionario = base.BuscarPorCodEntid(codEntidFuncionario);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(cdEmpresa);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;

            return funcionario;
        }
    }
}
