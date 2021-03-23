namespace Intech.PrevSystem.Entidades.Outros
{
    public class ItemTransacaoEntidade
    {
        public string Titulo { get; set; }
        public string Valor { get; set; }

        public ItemTransacaoEntidade() { }

        public ItemTransacaoEntidade(string titulo, string valor)
        {
            Titulo = titulo;
            Valor = valor;
        }
    }
}
