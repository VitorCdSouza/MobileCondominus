using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelaLogin.Models
{
    public class Aviso
    {
        public int IdAviso { get; set; }
        public string AssuntoAviso { get; set; }
        public string MensagemAviso { get; set; }
        public DateTime DataEnvioAviso { get; set; }
        public string TipoAviso { get; set; }
        public string IdCondominioAviso { get; set; }
    }
}