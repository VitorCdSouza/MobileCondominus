using TelaLogin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaLogin.Services.Comunicacao
{
    public class AvisosService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://26.155.159.147:5237/Notificacoes";

        private string _token;
        public AvisosService(string token)
        {
            _request = new Request();
            _token = token; //mudar para tokenUsuario
        }
        #region metodos

        public async Task<ObservableCollection<NotificacaoDTO>> GetAvisosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAvisosCondominio");
            ObservableCollection<NotificacaoDTO> listaAvisos = await
            _request.GetAsync<ObservableCollection<NotificacaoDTO>>(apiUrlBase + urlComplementar, _token);

            return listaAvisos;
        }
        #endregion
    }
}
