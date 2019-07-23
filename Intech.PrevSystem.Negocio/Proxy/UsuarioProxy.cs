#region Usings
using Intech.Lib.Email;
using Intech.Lib.Util.Seguranca;
using Intech.Lib.Web;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using System; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class UsuarioProxy : UsuarioDAO
    {
        private Exception ExceptionDadosInvalidos => new Exception("Dados inválidos!");

        public override UsuarioEntidade BuscarPorLogin(string NOM_LOGIN, string PWD_USUARIO)
        {
            var senha = Criptografia.Encriptar(PWD_USUARIO);

            return base.BuscarPorLogin(NOM_LOGIN, senha);
        }

        public string AlterarSenha(string cpf, string senhaAntiga, string senhaNova)
        {
            var usuarioExistente = BuscarPorLogin(cpf, senhaAntiga);

            if (usuarioExistente == null)
                throw new Exception("Senha antiga incorreta!");

            usuarioExistente.PWD_USUARIO = Criptografia.Encriptar(senhaNova);
            Atualizar(usuarioExistente);

            return "Senha alterada com sucesso!";
        }

        public string AlterarSenhaPrimeiroAcesso(string cpf, string senhaNova)
        {
            var usuarioExistente = BuscarPorCpf(cpf);

            usuarioExistente.PWD_USUARIO = Criptografia.Encriptar(senhaNova);
            usuarioExistente.IND_PRIMEIRO_ACESSO = DMN_SN.NAO;
            Atualizar(usuarioExistente);

            return "Senha alterada com sucesso!";
        }

        public void CriarAcessoIntech(string cpf, string chave)
        {
            if (chave != "Intech456#@!")
                throw ExceptionDadosInvalidos;

            cpf = cpf.LimparMascara();

            var funcionario = new FuncionarioProxy().BuscarPrimeiroPorCpf(cpf);

            if (funcionario == null)
                throw ExceptionDadosInvalidos;

            var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(funcionario.COD_ENTID.ToString());
            
            var senhaEncriptada = Criptografia.Encriptar("123");

            // Verifica se existe usuário. Caso sim, atualiza a senha. Caso não, cria novo usuário.
            var usuarioExistente = BuscarPorCpf(cpf);

            if (usuarioExistente != null)
            {
                usuarioExistente.PWD_USUARIO = senhaEncriptada;
                Atualizar(usuarioExistente);
            }
            else
            {
                var novoUsuario = new UsuarioEntidade
                {
                    NOM_LOGIN = cpf,
                    PWD_USUARIO = senhaEncriptada,
                    CD_EMPRESA = funcionario.CD_EMPRESA,
                    DES_LOTACAO = null,
                    DTA_ATUALIZACAO = DateTime.Now,
                    DTA_CRIACAO = DateTime.Now,
                    IND_ADMINISTRADOR = "N",
                    IND_ATIVO = "S",
                    IND_BLOQUEADO = "N",
                    NOM_USUARIO_ATUALIZACAO = null,
                    NOM_USUARIO_CRIACAO = null,
                    NUM_TENTATIVA = 0,
                    SEQ_RECEBEDOR = null
                };

                Inserir(novoUsuario);
            }
        }

        public string CriarAcesso(string cpf, DateTime dataNascimento)
        {
            var funcionarioProxy = new FuncionarioProxy();

            cpf = cpf.LimparMascara();
            
            string codEntid;
            decimal seqRecebedor;
            var funcionario = funcionarioProxy.BuscarPrimeiroPorCpf(cpf);

            if (funcionario != null)
            {
                codEntid = funcionario.COD_ENTID.ToString();
                seqRecebedor = 0;
            }
            else
            {
                var recebedorBeneficio = new RecebedorBeneficioProxy().BuscarPensionistaPorCpf(cpf);

                if (recebedorBeneficio == null)
                    throw ExceptionDadosInvalidos;

                codEntid = recebedorBeneficio.COD_ENTID.ToString();
                funcionario = funcionarioProxy.BuscarPorMatricula(recebedorBeneficio.NUM_MATRICULA);
                seqRecebedor = recebedorBeneficio.SEQ_RECEBEDOR;
            }

            if (codEntid != null)
            {
                var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);

                if (dadosPessoais.DT_NASCIMENTO != dataNascimento)
                    throw ExceptionDadosInvalidos;

                var senha = new Random().Next(999999).ToString();
                var senhaEncriptada = Criptografia.Encriptar(senha);

                // Verifica se existe usuário. Caso sim, atualiza a senha. Caso não, cria novo usuário.
                var usuarioExistente = BuscarPorCpf(cpf);

                if (usuarioExistente != null)
                {
                    usuarioExistente.PWD_USUARIO = senhaEncriptada;
                    Atualizar(usuarioExistente);
                }
                else
                {
                    var novoUsuario = new UsuarioEntidade
                    {
                        NOM_LOGIN = cpf,
                        PWD_USUARIO = senhaEncriptada,
                        CD_EMPRESA = funcionario.CD_EMPRESA,
                        DES_LOTACAO = null,
                        DTA_ATUALIZACAO = DateTime.Now,
                        DTA_CRIACAO = DateTime.Now,
                        IND_ADMINISTRADOR = "N",
                        IND_ATIVO = "S",
                        IND_BLOQUEADO = "N",
                        NOM_USUARIO_ATUALIZACAO = null,
                        NOM_USUARIO_CRIACAO = null,
                        NUM_TENTATIVA = 0,
                        SEQ_RECEBEDOR = seqRecebedor
                    };

                    Inserir(novoUsuario);
                }

                // Envia e-mail com nova senha de acesso
                var emailConfig = AppSettings.Get().Email;

                var emails = dadosPessoais.EMAIL_AUX.Split(';');

                foreach (var email in emails)
                {
                    EnvioEmail.EnviarMailKit(emailConfig, email.Trim(), $"{AppSettings.Get().Cliente} - Nova senha de acesso", $"Esta é sua nova senha da Área Restrita {AppSettings.Get().Cliente}: {senha}");
                }

                return "Sua nova senha foi enviada para seu e-mail!";
            }

            throw ExceptionDadosInvalidos;
        }
    }
}