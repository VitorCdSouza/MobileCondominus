using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaLogin.Models
{
    public class Acesso
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public string Rg { get; set; }
            public string Finalidade { get; set; }
            public DateTime Nascimento { get; set; }
            public string Telefone { get; set; }
            public string Observacoes { get; set; }
            public DateTime Data { get; set; }


    }
}
