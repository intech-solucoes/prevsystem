#region Usings
using Intech.Lib.Email;
using Intech.Lib.Util.Seguranca;
using Intech.Lib.Util.Validacoes;
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
                throw new Exception("Senha atual incorreta!");

            AtualizarSenhaPrimeiroAcesso(usuarioExistente.OID_USUARIO, Criptografia.Encriptar(senhaNova), "N");

            return "Senha alterada com sucesso!";
        }

        public string AlterarSenhaPrimeiroAcesso(string cpf, string senhaNova)
        {
            cpf = cpf.LimparMascara();
            var usuarioExistente = BuscarPorCpf(cpf);

            AtualizarSenhaPrimeiroAcesso(usuarioExistente.OID_USUARIO, Criptografia.Encriptar(senhaNova), "N");

            return "Senha alterada com sucesso!";
        }

        public void Insert(UsuarioEntidade usuario)
        {
            base.Insert(usuario.NOM_LOGIN, usuario.PWD_USUARIO, usuario.IND_BLOQUEADO, usuario.NUM_TENTATIVA, usuario.DES_LOTACAO, usuario.IND_ADMINISTRADOR, usuario.IND_ATIVO, usuario.NOM_USUARIO_CRIACAO, usuario.DTA_CRIACAO, usuario.NOM_USUARIO_ATUALIZACAO, usuario.DTA_ATUALIZACAO, usuario.CD_EMPRESA, usuario.IND_PRIMEIRO_ACESSO, usuario.SEQ_RECEBEDOR);
        }

        public void CriarAcessoIntech(string cpf, string chave, string senha = "123")
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

                var senhaEncriptada = Criptografia.Encriptar(senha);

                // Verifica se existe usu�rio. Caso sim, atualiza a senha. Caso n�o, cria novo usu�rio.
                var usuarioExistente = BuscarPorCpf(cpf);

                if (usuarioExistente != null)
                {
                    AtualizarSenhaPrimeiroAcesso(usuarioExistente.OID_USUARIO, senhaEncriptada, "N");
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
                        SEQ_RECEBEDOR = seqRecebedor,
                        IND_PRIMEIRO_ACESSO = "N"
                    };

                    Insert(novoUsuario);
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
                var usarSenhaComplexa = AppSettings.Get().SenhaComplexa || false;
                var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);

                if (dadosPessoais.DT_NASCIMENTO != dataNascimento)
                    throw ExceptionDadosInvalidos;

                if (string.IsNullOrEmpty(dadosPessoais.EMAIL_AUX))
                    throw new Exception("Voc� n�o poss�i um e-mail cadastrado. Por favor, entre em contato com a Preves.");

                var senha = GerarSenha(usarSenhaComplexa);

                var senhaEncriptada = Criptografia.Encriptar(senha);

                // Verifica se existe usu�rio. Caso sim, atualiza a senha. Caso n�o, cria novo usu�rio.
                var usuarioExistente = BuscarPorCpf(cpf);

                if (usuarioExistente != null)
                {
                    AtualizarSenhaPrimeiroAcesso(usuarioExistente.OID_USUARIO, senhaEncriptada, "S");
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
                        SEQ_RECEBEDOR = seqRecebedor,
                        IND_PRIMEIRO_ACESSO = "S"
                    };

                    Insert(novoUsuario);
                }

                // Envia e-mail com nova senha de acesso
                var emailConfig = AppSettings.Get().Email;

                var emails = dadosPessoais.EMAIL_AUX.Split(';');

                foreach (var email in emails)
                {
                    if (!Validador.ValidarEmail(email))
                        throw new Exception("E-mail em formato inv�lido!");

                    EnvioEmail.Enviar(emailConfig, email.Trim(), $"{AppSettings.Get().Cliente} - Nova senha de acesso", $"Esta � sua nova senha da �rea Restrita {AppSettings.Get().Cliente}: {senha}");
                }

                return "Sua nova senha foi enviada para seu e-mail!";
            }

            throw ExceptionDadosInvalidos;
        }

        private static string GerarSenha(bool senhaComplexa = false)
        {
            if (senhaComplexa)
                return (String.Concat(gerarCharSpecial(), gerarLetraMaiscula(), gerarLetraMinuscula(), gerarCharSpecial())) + (new Random().Next(99).ToString());
            else
                return new Random().Next(999999).ToString();
        }

        //var chars = [gerarCharSpecial, gerarLetraMaiscula, senha, gerarLetraMinuscula, gerarCharSpecial];
        //senha = String.Concat(chars);
             
        public static string gerarLetraMinuscula()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num].ToString();
        }

        public static string gerarLetraMaiscula()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num].ToString();
        }

        public static string gerarCharSpecial()
        {
            string chars = "$%#@!*?;:^&";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num].ToString();
        }

    }
}
