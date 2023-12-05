using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelaLogin.Models
{
    public class PessoaAreaComumDTO
    {
        public int Id { get; set; }
        public string NomeAreaPessAreaDTO { get; set; }
        public DateTime dataHoraInicioPessAreaDTO { get; set; }
        public DateTime dataHoraFimPessAreaDTO { get; set; }
        public string NomePessoaDTO { get; set; }
        public int IdPessoaPessAreaDTO { get; set; }
        public int IdAreaComumPessAreaDTO { get; set; }
    }
}