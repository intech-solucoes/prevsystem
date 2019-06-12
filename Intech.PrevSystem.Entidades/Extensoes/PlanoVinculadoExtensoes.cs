using Intech.PrevSystem.Entidades;

namespace System
{
    public static class PlanoVinculadoExtensoes
    {
        public static bool IsAtivo(this PlanoVinculadoEntidade plano) => plano.CD_CATEGORIA == "1";
        public static bool IsDesligado(this PlanoVinculadoEntidade plano) => plano.CD_CATEGORIA == "2";
        public static bool IsAutopatrocinio(this PlanoVinculadoEntidade plano) => plano.CD_CATEGORIA == "3";
        public static bool IsAssistido(this PlanoVinculadoEntidade plano) => plano.CD_CATEGORIA == "4";
    }
}
