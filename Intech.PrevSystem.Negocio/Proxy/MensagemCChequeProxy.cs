using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class MensagemCChequeProxy : MensagemCChequeDAO
    {
        public string BuscarTextoMensagens(string CD_FUNDACAO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA, string CD_EMPRESA, string CD_PLANO, string CD_ESPECIE, int? SEQ_RECEBEDOR, string CD_RUBRICA)
        {
            var sbMensagens = new StringBuilder();
            List<MensagemCChequeEntidade> mensagens;

            if(string.IsNullOrEmpty(CD_RUBRICA))
                mensagens = base.BuscarMensagens(CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA, CD_EMPRESA, CD_PLANO, CD_ESPECIE, SEQ_RECEBEDOR).ToList();
            else
                mensagens = base.BuscarMensagens(CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA, CD_EMPRESA, CD_PLANO, CD_ESPECIE, SEQ_RECEBEDOR).ToList();
            
            foreach (var mensagem in mensagens)
            {
                sbMensagens.Append($"{mensagem.MENSAGEM} " +
                    $"{mensagem.MENSAGEM_2} " +
                    $"{mensagem.MENSAGEM_3} " +
                    $"{mensagem.MENSAGEM_4} " +
                    $"{mensagem.MENSAGEM_5} " +
                    $"{mensagem.MENSAGEM_6} " +
                    $"{mensagem.MENSAGEM_7} " +
                    $"{mensagem.MENSAGEM_8} " +
                    $"{mensagem.MENSAGEM_9} " +
                    $"{mensagem.MENSAGEM_10} " +
                    $"{mensagem.MENSAGEM_11}");
            }

            return sbMensagens.ToString();
        }
    }
}
