#region Usings
using System;
using System.Collections.Generic; 
#endregion

namespace Intech.PrevSystem.Entidades
{
    public class RecadastramentoCampoEntidade
    {
        public string ID { get; set; }

        public string Titulo { get; set; }

        public string ValorAntigo { get; set; }

        public string NovoValor { get; set; }

        public string NovoValorCombo { get; set; }

        public string TipoCampo { get; set; }

        public bool PodeComprovar { get; set; }

        public bool ExigeComprovacao { get; set; }

        public bool Editavel { get; set; }

        public string Arquivo { get; set; }

        public bool ComprovacaoAnexada { get; set; }

        public string CssClassValidation { get; set; }

        public int MaxSize { get; set; }

        public List<Tuple<string, string>> Valores { get; set; }

        public RecadastramentoCampoEntidade() { }

        public RecadastramentoCampoEntidade(string id, string titulo, string tipoCampo, bool editavel, string valor, int maxSize, string cssClassValidation, bool podeComprovar = false, bool exigeComprovacao = false)
        {
            ID = id;
            Titulo = titulo;
            TipoCampo = tipoCampo;
            Editavel = editavel;
            ValorAntigo = NovoValor = NovoValorCombo = valor;
            MaxSize = maxSize;
            CssClassValidation = cssClassValidation;
            PodeComprovar = podeComprovar;
            ExigeComprovacao = exigeComprovacao;
        }

        public RecadastramentoCampoEntidade(string id, string titulo, string tipoCampo, bool editavel, string valor, List<Tuple<string, string>> valores, bool podeComprovar = false, bool exigeComprovacao = false)
        {
            ID = id;
            Titulo = titulo;
            TipoCampo = tipoCampo;
            Editavel = editavel;
            ValorAntigo = NovoValor = NovoValorCombo = valor;
            PodeComprovar = podeComprovar;
            ExigeComprovacao = exigeComprovacao;
            Valores = valores;
        }
    }

    public class TipoCampo
    {
        public const string Texto = "TXT";

        public const string Combo = "CMB";
    }
}
