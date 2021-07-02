using Intech.PrevSystem.Entidades;
using System.Collections.Generic;

namespace Intech.PrevSystem.Negocio.Emprestimo
{
    public class TaxaConcessao
    {
        public decimal Oid { get; set; }
        public string COD_IND { get; set; }
        public decimal SEQUENCIA { get; set; }
        public string IND_DEFAZAGEM { get; set; }
        public decimal? IND_MESES_DEFAZAGEM { get; set; }
        public string TIPO_IND { get; set; }
        public decimal? TX_JUROS { get; set; }
        public string IND_CALC_PREST_CONC { get; set; }

        #region Métodos Publicos

        public static TaxaConcessao Criar(TaxasConcessaoEntidade row)
        {
            return new TaxaConcessao
            {
                COD_IND = row.COD_IND,
                IND_DEFAZAGEM = row.IND_DEFAZAGEM,
                IND_MESES_DEFAZAGEM = row.IND_MESES_DEFAZAGEM,
                TIPO_IND = row.TIPO_IND,
                SEQUENCIA = row.SEQUENCIA,
                TX_JUROS = row.TX_JUROS,
                IND_CALC_PREST_CONC = row.IND_CALC_PREST_CONC
            };
        }

        public static TaxaConcessao Criar(TaxasConcessaoPlanoEntidade row)
        {
            return new TaxaConcessao
            {
                COD_IND = row.COD_IND,
                IND_DEFAZAGEM = row.IND_DEFAZAGEM,
                IND_MESES_DEFAZAGEM = row.IND_MESES_DEFAZAGEM,
                TIPO_IND = row.TIPO_IND,
                SEQUENCIA = row.SEQUENCIA,
                TX_JUROS = row.TX_JUROS,
                IND_CALC_PREST_CONC = row.IND_CALC_PREST_CONC
            };
        }

        public static IEnumerable<TaxaConcessao> Criar(List<TaxasConcessaoEntidade> dtConcessao)
        {
            foreach (var row in dtConcessao)
            {
                yield return new TaxaConcessao
                {
                    COD_IND = row.COD_IND,
                    IND_DEFAZAGEM = row.IND_DEFAZAGEM,
                    IND_MESES_DEFAZAGEM = row.IND_MESES_DEFAZAGEM,
                    TIPO_IND = row.TIPO_IND,
                    SEQUENCIA = row.SEQUENCIA,
                    TX_JUROS = row.TX_JUROS,
                    IND_CALC_PREST_CONC = row.IND_CALC_PREST_CONC
                };
            }
        }

        public static IEnumerable<TaxaConcessao> Criar(List<TaxasConcessaoPlanoEntidade> dtConcessao)
        {
            foreach (var row in dtConcessao)
            {
                yield return new TaxaConcessao
                {
                    COD_IND = row.COD_IND,
                    IND_DEFAZAGEM = row.IND_DEFAZAGEM,
                    IND_MESES_DEFAZAGEM = row.IND_MESES_DEFAZAGEM,
                    TIPO_IND = row.TIPO_IND,
                    SEQUENCIA = row.SEQUENCIA,
                    TX_JUROS = row.TX_JUROS,
                    IND_CALC_PREST_CONC = row.IND_CALC_PREST_CONC
                };
            }
        }

        #endregion
    }
}
