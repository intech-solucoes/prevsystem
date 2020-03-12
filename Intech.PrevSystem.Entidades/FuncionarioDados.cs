

namespace Intech.PrevSystem.Entidades
{

    public class FuncionarioDados
    {
        public DadosPessoaisEntidade DadosPessoais { get; set; }
        public FuncionarioEntidade Funcionario { get; set; }
        public EntidadeEntidade Entidade { get; set; }
        public EmpresaEntidade Empresa { get; set; }
        public UsuarioEntidade Usuario { get; set; }
        public string NOME_EMPRESA { get; set; }
        public string CPF { get; set; }
        public string SEXO { get; set; }
        public string IDADE { get; set; }
        public string CEP { get; set; }
        public string DS_ESTADO_CIVIL { get; set; }
        public string CNPJ_EMPRESA { get; set; }
        public string TIPO { get; set; }
        public string IND_AFA_JUDICIAL { get; set; }
    }

}