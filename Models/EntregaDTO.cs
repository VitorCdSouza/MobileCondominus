using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelaLogin.Models
{
    public class EntregaDTO
    {
        public int Id { get; set; }
        public string DestinatarioEntDTO { get; set; }
        public string NumeroApartDTO { get; set; }
        public DateTime? DataEntregaEntDTO { get; set; }
        public DateTime? DataRetiradaEntDTO { get; set; }
    }
}