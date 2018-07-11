#region Usings
using System.Collections.Generic; 
#endregion

namespace Intech.PrevSystem.Entidades
{
    public class RecadastramentoPassoEntidade
    {
        public string Titulo { get; set; }

        public string Subtitulo { get; set; }

        public string MensagemInicio { get; set; }

        public string MensagemFim { get; set; }

        public List<RecadastramentoGrupoEntidade> GrupoCampos { get; set; } = new List<RecadastramentoGrupoEntidade>();

        public int Numero { get; set; }
    }
}
