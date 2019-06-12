using Intech.PrevSystem.Entidades;
using System.Collections.Generic;

namespace Intech.PrevSystem.Negocio.Sabesprev.Relatorios
{
    public class RelatorioCAC
    {
        public List<FuncionarioDados> Dados { get; set; }
        public List<ContratoDisponivel> Contrato { get; set; }

        public RelatorioCAC(FuncionarioDados dados, ContratoDisponivel contrato)
        {
            Dados = new List<FuncionarioDados> {
                dados
            };

            Contrato = new List<ContratoDisponivel>
            {
                contrato
            };
        }
    }
}