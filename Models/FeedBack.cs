using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaLogin.Models
{
    public class FeedBack
    { 
    public int Id { get; set; }
    public string Assunto { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataEnvio { get; set; }
    public Pessoa Pessoa { get; set; }
    public int IdPessoa { get; set; }
}
}
