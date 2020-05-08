using Intech.PrevSystem.Entidades;
using System.Collections.Generic;

namespace Intech.PrevSystem.Negocio.Sabesprev.Relatorios
{
    public class RelatorioDeclaracaoIR
    {
        public RelatorioDeclaracaoIR(FuncionarioDados funcionario, List<DeclaracaoIR> dados, string ano)
        {
            Funcionario = funcionario;
            Dados = dados;
            Ano = ano;
        }

        public FuncionarioDados Funcionario { get; set; }
        public List<DeclaracaoIR> Dados { get; set; }
        public string Ano { get; set; }
    }

    public class DeclaracaoIR
    {
        public string Plano { get; set; }
        public string CNPB { get; set; }
        public string Valor { get; set; }
        public string ValorPorExtenso { get; set; }
    }
}