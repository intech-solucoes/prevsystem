using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intech.PrevSystem.Entidades.Extensoes
{
    public static class HeaderInfoRend
    {
        public static HeaderInfoRendEntidade PreencherGrupos(this HeaderInfoRendEntidade header)
        {
            header.Grupos.ForEach(infoRend =>
            {
                infoRend.COD_GRUPO = infoRend.COD_LINHA.Substring(0, 1);
                
                infoRend.DES_GRUPO = DicionarioGrupos.Single(x => x.Key == infoRend.COD_GRUPO).Value;

                if (!string.IsNullOrEmpty(infoRend.TXT_QUADRO))
                    infoRend.DES_INFO_REND = infoRend.TXT_QUADRO;
                else
                    infoRend.DES_INFO_REND = DicionarioLinhas.SingleOrDefault(x => x.Key == infoRend.COD_LINHA).Value;
            });

            return header;
        }

        public static List<KeyValuePair<string, string>> DicionarioGrupos = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("1", "FONTE PAGADORA PESSOA JURÍDICA"),
            new KeyValuePair<string, string>("2", "PESSOA FÍSICA BENEFICIÁRIA DOS RENDIMENTOS"),
            new KeyValuePair<string, string>("3", "RENDIMENTOS TRIBUTÁVEIS, DEDUÇÕES E IMPOSTO RETIDO NA FONTE"),
            new KeyValuePair<string, string>("4", "RENDIMENTOS ISENTOS E NÃO TRIBUTÁVEIS"),
            new KeyValuePair<string, string>("5", "RENDIMENTOS SUJEITOS À TRIBUTAÇÃO EXCLUSIVA (RENDIMENTO LÍQUIDO)"),
            new KeyValuePair<string, string>("6", "RENDIMENTOS RECEBIDOS ACUMULADAMENTE"),
            new KeyValuePair<string, string>("7", "INFORMAÇÕES COMPLEMENTARES")
        };

        public static List<KeyValuePair<string, string>> DicionarioLinhas = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("301", "Total dos Rendimentos (inclusive férias)"),
            new KeyValuePair<string, string>("302", "Contribuição Previdência Oficial"),
            new KeyValuePair<string, string>("303", "Contribuição a entidade de previdência complementar, pública ou privada, e a fundos de aposentadoria programada individual (Fapi) (preencher também o quadro 7)"),
            new KeyValuePair<string, string>("304", "Pensão Alimentícia"),
            new KeyValuePair<string, string>("305", "Imposto sobre a renda retido na fonte"),
            new KeyValuePair<string, string>("401", "Parcela isenta dos proventos de aposentadoria, reserva remunerada, reforma e pensão (65 anos ou mais)"),
            new KeyValuePair<string, string>("402", "Diárias e Ajudas de Custo"),
            new KeyValuePair<string, string>("403", "Pensão e proventos de aposentadoria ou reforma por moléstia grave, proventos de aposentadoria ou reforma por acidente em serviço"),
            new KeyValuePair<string, string>("404", "Lucro e Dividendo Apurado a partir de 1996 pago por PJ (Lucro Real, Presumido ou Arbitrado)"),
            new KeyValuePair<string, string>("405", "Valores Pagos ao Titular ou Sócio da Microempresa ou Empresa de Pequeno Porte, exceto Pro-labore, Aluguéis ou Serviços Prestados"),
            new KeyValuePair<string, string>("406", "Indenizações por rescisão de contrato de trabalho, inclusive a título de PDV, e acidente de trabalho"),
            new KeyValuePair<string, string>("407", "Outros"),
            new KeyValuePair<string, string>("501", "Décimo Terceiro Salário"),
            new KeyValuePair<string, string>("502", "Imposto sobre a renda retida na fonte sobre o 13º salário"),
            new KeyValuePair<string, string>("503", "Outros"),
            new KeyValuePair<string, string>("601", "Total dos rendimentos tributáveis (inclusive férias e décimo terceiro salário"),
            new KeyValuePair<string, string>("602", "Exclusão: Despesas com a ação judicial"),
            new KeyValuePair<string, string>("603", "Dedução: Contribuição previdenciária oficial"),
            new KeyValuePair<string, string>("604", "Dedução: Pensão Alimentícia (preencher também o quadro 7)"),
            new KeyValuePair<string, string>("605", "Imposto sobre a renda retido na fonte"),
            new KeyValuePair<string, string>("606", "Rendimentos isentos de pensão, proventos de aposentadoria ou reforma por moléstia grave ou aposentadoria ou reforma por acidente de serviço"),
            new KeyValuePair<string, string>("701", "Informações Complementares")
        };
    }
}
