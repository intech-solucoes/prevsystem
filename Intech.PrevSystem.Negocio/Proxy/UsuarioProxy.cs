#region Usings
using Intech.Lib.Email;
using Intech.Lib.Util.Seguranca;
using Intech.Lib.Web;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using System;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class UsuarioProxy : UsuarioDAO
    {
        private Exception ExceptionDadosInvalidos => new Exception("Dados inv�lidos!");

        public override UsuarioEntidade BuscarPorLogin(string NOM_LOGIN, string PWD_USUARIO)
        {
            NOM_LOGIN = NOM_LOGIN.LimparMascara();
            PWD_USUARIO = Criptografia.Encriptar(PWD_USUARIO);

            return base.BuscarPorLogin(NOM_LOGIN, PWD_USUARIO);
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
            cpf = cpf.LimparMascara();
            var usuarioExistente = BuscarPorCpf(cpf);

            usuarioExistente.PWD_USUARIO = Criptografia.Encriptar(senhaNova);
            usuarioExistente.IND_PRIMEIRO_ACESSO = DMN_SN.NAO;

            Atualizar(usuarioExistente);

            return "Senha alterada com sucesso!";
        }

        public void CriarAcessoIntech(string cpf, string chave)
        {
            cpf = cpf.LimparMascara();

            if (chave != "Intech456#@!")
                throw ExceptionDadosInvalidos;

            var funcionarioProxy = new FuncionarioProxy();

            string codEntid;
            decimal seqRecebedor;
            var funcionario = funcionarioProxy.BuscarPrimeiroPorCpf(cpf).FirstOrDefault();

            if (funcionario != null)
            {
                codEntid = funcionario.COD_ENTID.ToString();
                seqRecebedor = 0;
            }
            else
            {
                var recebedorBeneficio = new RecebedorBeneficioProxy().BuscarPensionistaPorCpf(cpf).First();

                if (recebedorBeneficio == null)
                    throw ExceptionDadosInvalidos;

                codEntid = recebedorBeneficio.COD_ENTID.ToString();
                funcionario = funcionarioProxy.BuscarPorMatricula(recebedorBeneficio.NUM_MATRICULA);
                seqRecebedor = recebedorBeneficio.SEQ_RECEBEDOR;
            }

            if (codEntid != null)
            {
                var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);

                var senhaEncriptada = Criptografia.Encriptar("123");

                // Verifica se existe usu�rio. Caso sim, atualiza a senha. Caso n�o, cria novo usu�rio.
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
            }
        }

        public string CriarAcesso(string cpf, DateTime dataNascimento)
        {
            cpf = cpf.LimparMascara();

            var funcionarioProxy = new FuncionarioProxy();
            
            string codEntid;
            decimal seqRecebedor;
            var funcionario = funcionarioProxy.BuscarPrimeiroPorCpf(cpf).FirstOrDefault();

            if (funcionario != null)
            {
                codEntid = funcionario.COD_ENTID.ToString();
                seqRecebedor = 0;
            }
            else
            {
                var recebedorBeneficio = new RecebedorBeneficioProxy().BuscarPensionistaPorCpf(cpf).First();

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

                // Verifica se existe usu�rio. Caso sim, atualiza a senha. Caso n�o, cria novo usu�rio.
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
                    EnvioEmail.Enviar(emailConfig, email.Trim(), $"{AppSettings.Get().Cliente} - Nova senha de acesso", $"Esta � sua nova senha da �rea Restrita {AppSettings.Get().Cliente}: {senha}");
                }

                return "Sua nova senha foi enviada para seu e-mail!";
            }

            throw ExceptionDadosInvalidos;
        }
    }
}