#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class DadosPessoaisProxy : DadosPessoaisDAO
    {
        public override DadosPessoaisEntidade BuscarPorCodEntid(string COD_ENTID)
        {
            var dadosPessoais = base.BuscarPorCodEntid(COD_ENTID);

            dadosPessoais.CPF_CGC = dadosPessoais.CPF_CGC.AplicarMascara(Mascaras.CPF);
            dadosPessoais.DS_SEXO = dadosPessoais.SEXO.Substring(0, 1).ToUpper() == "F" ? "FEMININO" : "MASCULINO";

            return dadosPessoais;
        }
    }
}