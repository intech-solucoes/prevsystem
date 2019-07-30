using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;

namespace Intech.PrevSystem.Negocio.Sabesprev.Relatorios
{
    public class RelatorioCAC
    {
        public List<FuncionarioDados> Dados { get; set; }
        public List<ContratoDisponivel> Contrato { get; set; }
        public string LocalData { get; set; }

        public RelatorioCAC(FuncionarioDados dados, ContratoDisponivel contrato)
        {
            Dados = new List<FuncionarioDados> {
                dados
            };

            Contrato = new List<ContratoDisponivel>
            {
                contrato
            };

            LocalData = $"São Paulo-SP, {DateTime.Now.Day} de {DateTime.Now:MMMM} de {DateTime.Now:yyyy}.";
        }
    }
}