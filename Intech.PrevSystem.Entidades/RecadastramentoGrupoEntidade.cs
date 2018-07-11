#region Usings
using System.Collections.Generic; 
#endregion

namespace Intech.PrevSystem.Entidades
{
    public class RecadastramentoGrupoEntidade
    {
        public string ID { get; set; }

        public string Titulo { get; set; }

        public bool PodeComprovar { get; set; }

        public bool ExigeComprovacao { get; set; }

        public bool PodeExcluir { get; set; }

        public bool Excluir { get; set; }

        public bool ComprovacaoAnexada { get; set; }

        public string Mensagem { get; set; }

        public List<RecadastramentoCampoEntidade> Campos { get; set; } = new List<RecadastramentoCampoEntidade>();
    }
}
