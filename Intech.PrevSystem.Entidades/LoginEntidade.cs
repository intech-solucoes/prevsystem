using System;

namespace Intech.PrevSystem.Entidades
{
    public class LoginEntidade
    {
        public string Cpf { get; set; }
        public string Inscricao { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CdEmpresa { get; set; }
        public string Chave { get; set; }
        public string SenhaAntiga { get; set; }
        public string SenhaNova { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}