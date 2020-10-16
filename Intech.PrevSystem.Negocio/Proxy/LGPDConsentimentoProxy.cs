using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class LGPDConsentimentoProxy : LGPDConsentimentoDAO
	{
        public void Insert(LGPDConsentimentoEntidade lgpd)
        {
            base.Insert(lgpd.COD_IDENTIFICADOR, lgpd.CD_FUNDACAO, lgpd.COD_CPF, lgpd.DTA_CONSENTIMENTO, lgpd.TXT_IPV4, lgpd.TXT_IPV6, lgpd.TXT_DISPOSITIVO, lgpd.TXT_ORIGEM);
        }
    }
}
