using System;
using Intech.Lib.Util.Seguranca;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class SegUsuarioProxy : SegUsuarioDAO
    {
        public override SegUsuarioEntidade BuscarPorLogin(string NOM_LOGIN, string PWD_USUARIO)
        {
            var senha = Criptografia.EncriptarMD5(PWD_USUARIO);

            return base.BuscarPorLogin(NOM_LOGIN, senha);
        }

        public UsuarioEntidade Migrar(dynamic NOM_LOGIN, dynamic PWD_USUARIO)
        {
            var segUsuario = BuscarPorLogin(NOM_LOGIN, PWD_USUARIO);

            var funcionario = new FuncionarioProxy().BuscarPorCpf(NOM_LOGIN);

            if(segUsuario != null)
            {
                var senha = Criptografia.Encriptar(PWD_USUARIO);

                var novoUsuario = new UsuarioEntidade
                {
                    CD_EMPRESA = funcionario.CD_EMPRESA,
                    DTA_CRIACAO = DateTime.Now,
                    DES_LOTACAO = null,
                    DTA_ATUALIZACAO = DateTime.Now,
                    IND_ADMINISTRADOR = "N",
                    IND_ATIVO = "S",
                    IND_BLOQUEADO = "N",
                    NOM_LOGIN = NOM_LOGIN,
                    NOM_USUARIO_ATUALIZACAO = NOM_LOGIN,
                    NOM_USUARIO_CRIACAO = NOM_LOGIN,
                    NUM_TENTATIVA = 0,
                    PWD_USUARIO = senha,
                    SEQ_RECEBEDOR = null
                };

                var oidWebUsuario = new UsuarioProxy().Inserir(novoUsuario);
                return novoUsuario;
            }

            return null;
        }
    }
}
