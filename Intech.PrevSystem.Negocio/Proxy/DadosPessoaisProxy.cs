#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class DadosPessoaisProxy : DadosPessoaisDAO
    {
        public dynamic BuscarDadosPorCodEntid(string COD_ENTID)
        {
            var dadosPessoais = base.BuscarPorCodEntid(COD_ENTID);



            return new
            {
                dadosPessoais,
                CPF = dadosPessoais.CPF_CGC.AplicarMascara(Mascaras.CPF),
                SEXO = dadosPessoais.SEXO.Substring(0, 1).ToUpper() == "F" ? "FEMININO" : "MASCULINO"
            };
        }
    }
}
