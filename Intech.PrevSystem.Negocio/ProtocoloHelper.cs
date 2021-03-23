﻿#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Outros;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Text; 
#endregion

namespace Intech.PrevSystem.Negocio
{
    public class ProtocoloHelper
    {
        public static IEnumerable<FuncionalidadeEntidade> BuscarFuncionalidades()
        {
            return new FuncionalidadeProxy().Listar();
        }

        public static string Criar(decimal OID_FUNCIONALIDADE, string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_MATRICULA, decimal? SEQ_RECEBEDOR, string conteudo,
                                   string TXT_USUARIO_SOLICITACAO, string TXT_USUARIO_EFETIVACAO, string TXT_IPV4, string TXT_IPV4_EXTERNO, string TXT_IPV6, string TXT_DISPOSITIVO, string TXT_ORIGEM, string COD_IDENTIFICADOR=null)
        {
            var proxyProtocolo = new ProtocoloProxy();

            var conteudo1 = conteudo;
            var conteudo2 = string.Empty;

            if (conteudo.Length > 4000)
            {
                conteudo1 = conteudo.Substring(0, 4000);
                conteudo2 = conteudo.Substring(4000);
            }

            var protocolo = COD_IDENTIFICADOR != null ? COD_IDENTIFICADOR :
                NUM_MATRICULA.TrimStart('0') + DateTime.Now.ToString("ddMMyyyyhhmmss");

            var protocoloEntidade = new ProtocoloEntidade
            {
                OID_FUNCIONALIDADE = OID_FUNCIONALIDADE,
                COD_IDENTIFICADOR = protocolo,
                CD_FUNDACAO = CD_FUNDACAO,
                CD_EMPRESA = CD_EMPRESA,
                CD_PLANO = CD_PLANO,
                NUM_MATRICULA = NUM_MATRICULA,
                SEQ_RECEBEDOR = SEQ_RECEBEDOR,
                DTA_SOLICITACAO = DateTime.Now,
                TXT_TRANSACAO = conteudo1,
                TXT_TRANSACAO2 = conteudo2,
                TXT_USUARIO_SOLICITACAO = TXT_USUARIO_SOLICITACAO,
                TXT_USUARIO_EFETIVACAO = TXT_USUARIO_EFETIVACAO,
                TXT_IPV4 = TXT_IPV4,
                TXT_IPV6 = TXT_IPV6,
                TXT_DISPOSITIVO = TXT_DISPOSITIVO,
                TXT_ORIGEM = TXT_ORIGEM,
            };
            var oidProtocolo = proxyProtocolo.Inserir(protocoloEntidade);
            var protocoloInserido = proxyProtocolo.BuscarPorChave(oidProtocolo);

            return protocoloInserido.COD_IDENTIFICADOR;
        }

        public static string MontarConteudo(List<ItemTransacaoEntidade> listaConteudo)
        {
            var sb = new StringBuilder();

            listaConteudo.ForEach(x =>
            {
                sb.AppendLine($"{x.Titulo}|{x.Valor}");
            });

            return sb.ToString();
        }

        public static List<ItemTransacaoEntidade> BuscarConteudo(string transacao)
        {
            var listaTransacao = new List<ItemTransacaoEntidade>();

            if (listaTransacao != null && listaTransacao.Count > 0)
                listaTransacao.Clear();

            transacao = transacao.Replace("\\n", "\n").Replace("\\r", "\r");

            foreach (var linha in transacao.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var item = linha.Split('|');
                listaTransacao.Add(new ItemTransacaoEntidade(item[0], item[1]));
            }

            return listaTransacao;
        }

        public static string BuscarProtocolo(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_MATRICULA, decimal NUM_FUNCIONALIDADE)
        {
            var protocolo = new ProtocoloProxy().BuscarAbertasPorFundacaoEmpresaPlanoMatriculaFuncionalidade(CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_MATRICULA, NUM_FUNCIONALIDADE);
            return protocolo.COD_IDENTIFICADOR;
        }
    }

    
}
