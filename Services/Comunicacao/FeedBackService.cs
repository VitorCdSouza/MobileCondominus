using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelaLogin.Models;
namespace TelaLogin.Services.Comunicacao
{
    public class FeedBackService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://condominus-api.somee.com/CondominusApi/Usuarios/1/Entregas/1";

        private string _token;
        public FeedBackService(string token)
        {
            _request = new Request();
            _token = token; //mudar para tokenUsuario
        }
        #region metodos

        public async Task<FeedBack> PostFeedBackAsync(FeedBack f)
        {
            return await _request.PostAsync(apiUrlBase, f, _token);
        }
        #endregion
    }
}

