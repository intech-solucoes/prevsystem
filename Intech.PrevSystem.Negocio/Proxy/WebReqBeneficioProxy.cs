using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebReqBeneficioProxy : WebReqBeneficioDAO
	{
		public WebReqBeneficioProxy (IDbTransaction tx = null) : base(tx) { }

        public void Insert(WebReqBeneficioEntidade dados) 
        {
            base.Insert(
                dados.CD_FUNDACAO,
                dados.NUM_INSCRICAO,
                dados.CD_PLANO,
                dados.CD_ESPECIE,
                dados.DTA_SOLICITACAO,
                dados.DES_ORIGEM,
                dados.IND_SITUACAO,
                dados.COD_VALIDACAO,
                dados.COD_PROTOCOLO,
                dados.DTA_EFETIVACAO,
                dados.DTA_RECUSA,
                dados.TXT_MOTIVO_RECUSA,
                dados.NUM_IDADE,
                dados.NUM_TEMPO_PATROC,
                dados.NUM_TEMPO_PLANO,
                dados.NUM_TEMPO_INSS,
                dados.DTA_ULTIMO_RECAD,
                dados.DTA_DEMISSAO,
                dados.COD_BANCO,
                dados.COD_AGENCIA,
                dados.COD_CONTA,
                dados.COD_DV_CONTA
            );
        }
    }
}
