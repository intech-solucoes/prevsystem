#region Usings
using Intech.Lib.Email;
using Intech.Lib.SMS;
using Intech.Lib.Util.Seguranca;
using Intech.Lib.Util.Validacoes;
using Intech.Lib.Web;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using System;
using System.Collections.Generic;
using System.IO;
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

        public string CriarAcesso(string cpf, DateTime dataNascimento, bool enviarEmail = true, bool enviarSms = false, Provedor provedor = Provedor.Zenvia)
        {
            var Cliente = AppSettings.Get().Cliente;
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
                var config = AppSettings.Get();

                if (enviarEmail)
                {
                    if (string.IsNullOrEmpty(dadosPessoais.EMAIL_AUX))
                        throw new Exception($"Você não possúi um e-mail cadastrado. Por favor, entre em contato com a {Cliente}.");

                    var email = dadosPessoais.EMAIL_AUX.Split(';')[0];

                    var showBegin = 1;

                    var emailEscondido = "";

                    for (var i = 0; i < email.Length; i++)
                    {
                        var indexArroba = email.IndexOf('@');
                        if (i > showBegin && i < indexArroba)
                            emailEscondido += "*";
                        else
                            emailEscondido += email[i];
                    }

                    if (!Validador.ValidarEmail(email))
                        throw new Exception("E-mail em formato inválido!");

                    var semAnexo = new List<KeyValuePair<string, Stream>>();
                    EnvioEmail.Enviar(config.Email, email.Trim(), $"{Cliente} - Nova senha de acesso", $"Esta é sua nova senha da área Restrita {Cliente}: \"{senha}\"", semAnexo);
                    
                    return $"Sua nova senha foi enviada para o e-mail {emailEscondido}!";
                }

                if(enviarSms)
                {
                    if (config.SMS == null || string.IsNullOrEmpty(config.SMS.Usuario) || string.IsNullOrEmpty(config.SMS.Senha))
                        throw new Exception("Favor configurar o usu�rio e senha para envio de TOKEN via SMS");

                    var celularEscondido = "";
                    var showBegin = 1;

                    for (var i = 0; i < dadosPessoais.FONE_CELULAR.Length; i++)
                    {
                        if (i > showBegin && i < dadosPessoais.FONE_CELULAR.Length - 3)
                            celularEscondido += "*";
                        else
                            celularEscondido += dadosPessoais.FONE_CELULAR[i];
                    }

                    var mensagem = $"Esta e sua nova senha da Area Restrita da {Cliente}: {senha}";
                    var retorno = new SMS()
                        .Enviar(provedor, dadosPessoais.FONE_CELULAR, config.SMS.Usuario, config.SMS.Senha, Cliente, mensagem, funcionario.NUM_MATRICULA, funcionario.NUM_INSCRICAO,
                            new EventHandler<SMSEventArgs>(delegate (object sender, SMSEventArgs args)
                            {
                                try
                                {
                                    var logSMSProxy = new LogSMSProxy();
                                    var Retorno = String.IsNullOrEmpty(args.Retorno) ? "Mensagem Enviada" : args.Retorno;
                                    logSMSProxy.Insert(Retorno, args.NumTelefone, args.Matricula, args.Inscricao);
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception($"Ocorreu erro ao gravar log de sms: Message: {ex.Message}, e StackTrace: {ex.StackTrace}");
                                }
                            }));

                    return $"Sua nova senha foi enviada via SMS para o número {celularEscondido}!";
                }
            }

            throw ExceptionDadosInvalidos;
        }

        private static string GerarSenha(bool senhaComplexa = false)
        {
            if (senhaComplexa)
                return (string.Concat(gerarCharSpecial(), gerarLetraMaiscula(), gerarLetraMinuscula(), gerarCharSpecial())) + (new Random().Next(99).ToString());
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
