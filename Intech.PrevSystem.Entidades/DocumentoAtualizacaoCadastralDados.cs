using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades
{
    public class DocumentoAtualizacaoCadastralDados
    {
        public decimal OID_ARQUIVO_UPLOAD { get; set; }
        public string NOM_ARQUIVO_ORIGINAL { get; set; }
        public string NOM_ARQUIVO_LOCAL { get; set; }
        public DateTime DTA_UPLOAD { get; set; }
        public string NOME_ENTID { get; set; }
    }
}
