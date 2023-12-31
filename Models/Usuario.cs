using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TelaLogin.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public byte[]? PasswordHashUsuario { get; set; }
        public byte[]? PasswordSaltUsuario { get; set; }
        public DateTime? DataAcessoUsuario { get; set; }
        public Pessoa PessoaUsuario { get; set; }
        public int IdPessoaUsuario { get; set; }

        [NotMapped]
        public string TokenUsuario { get; set; }
        [NotMapped]
        public string SenhaUsuario { get; set; }
    }
}

