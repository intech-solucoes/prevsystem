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
            var mensagens = base.BuscarMensagens(CD_FUNDACAO, DT_REFERENCIA, CD_TIPO_FOLHA).ToList();

            // CD_EMPRESA
            mensagens = mensagens
                .Where(x => string.IsNullOrEmpty(CD_EMPRESA) ? x.CD_EMPRESA == null : x.CD_EMPRESA == CD_EMPRESA)
                .Where(x => string.IsNullOrEmpty(CD_PLANO) ? x.CD_PLANO == null : x.CD_PLANO == CD_PLANO)
                .Where(x => string.IsNullOrEmpty(CD_ESPECIE) ? x.CD_ESPECIE == null : x.CD_ESPECIE == CD_ESPECIE)
                .Where(x => x.SEQ_RECEBEDOR == null)
                    //&& (!SEQ_RECEBEDOR.HasValue || SEQ_RECEBEDOR.Value == 0) ? x.SEQ_RECEBEDOR == null : x.SEQ_RECEBEDOR == SEQ_RECEBEDOR
                .ToList();

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
                    $"{mensagem.MENSAGEM_11} ");
            }

            if (string.IsNullOrWhiteSpace(sbMensagens.ToString()))
                return "";

            return sbMensagens.ToString().ToUpper().Trim();
        }
    }
}
