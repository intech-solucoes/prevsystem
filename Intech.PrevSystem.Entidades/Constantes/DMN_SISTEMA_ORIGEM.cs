using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades.Constantes
{
    public class DMN_SISTEMA_ORIGEM
    {
        public static KeyValuePair<int, string> PORTAL = new KeyValuePair<int, string>(1, "PORTAL PARTICIPANTE");
        public static KeyValuePair<int, string> MOBILE = new KeyValuePair<int, string>(2, "MOBILE");

        public static string Valor(int chave)
        {
            switch(chave)
            {
                case 1:
                    return PORTAL.Value;
                case 2:
                    return MOBILE.Value;
                default:
                    throw new Exception("Chave não encontrada!");
            }
        }
    }
}