using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelaLogin.Models
{
    public class Dependente
    {
        public int Id { get; set; }
        public string NomeDependente { get; set; }
        public string CpfDependente { get; set; }
        public string NomePessoaDependenteDTO { get; set; }
    }
}