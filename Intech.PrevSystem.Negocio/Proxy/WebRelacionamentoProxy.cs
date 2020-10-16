using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebRelacionamentoProxy : WebRelacionamentoDAO
	{
        public void Insert(WebRelacionamentoEntidade entidade)
        {
            base.Insert(entidade.CD_FUNDACAO, entidade.COD_CPF, entidade.DTA_ENVIO, entidade.TXT_EMAIL_DESTINATARIO, entidade.TXT_EMAIL_REMETENTE, entidade.OID_ASSUNTO, entidade.TXT_MENSAGEM, entidade.TXT_IPV4, entidade.TXT_IPV6, entidade.TXT_DISPOSITIVO);
        }
    }
}
