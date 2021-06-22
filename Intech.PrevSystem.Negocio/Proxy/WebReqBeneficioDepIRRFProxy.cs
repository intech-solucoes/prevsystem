using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebReqBeneficioDepIRRFProxy : WebReqBeneficioDepIRRFDAO
	{
		public WebReqBeneficioDepIRRFProxy (IDbTransaction tx = null) : base(tx) { }

        public void Insert(WebReqBeneficioDepIRRFEntidade dados)
        {
            base.Insert(
                dados.OID_REQ_BENEFICIO,
                dados.NUM_SEQ_DEP,
                dados.NOM_DEPENDENTE,
                dados.COD_GRAU_PARENTESCO,
                dados.DES_GRAU_PARENTESCO,
                dados.DTA_NASCIMENTO,
                dados.DTA_INICIO_IRRF,
                dados.DTA_TERMINO_IRRF,
                dados.COD_SEXO,
                dados.DES_SEXO,
                dados.COD_CPF,
                dados.IND_OPERACAO
            );
        }
    }
}
