using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelaLogin.Models
{
    public class NotificacaoDTO
    {
        public int IdNotificacaoDTO { get; set; }
        public string AssuntoNotificacaoDTO { get; set; }
        public string MensagemNotificacaoDTO { get; set; }
        public DateTime DataEnvioNotificacaoDTO { get; set; }
        public string TipoNotificacaoDTO { get; set; }
        public string IdCondominioNotificacaoDTO { get; set; }
    }
}