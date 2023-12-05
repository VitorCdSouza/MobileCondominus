
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TelaLogin.Models;

namespace TelaLogin.Services.PessoasAreas
{
    public class PessoasAreasService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://26.155.159.147:5237/PessoasAreasComuns";

        private string _token;
        public PessoasAreasService(string token)
        {
            _request = new Request();
            _token = token; //mudar para tokenUsuario
        }
        #region
       
    public async Task<PessoaAreaComumDTO> PostPessoaAreasAsync(PessoaAreaComumDTO r)
    {
        return await _request.PostAsync(apiUrlBase, r, _token);
    }
        public async Task<ObservableCollection<PessoaAreaComumDTO>> GetPessoaAreasAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAllCondominio");
            ObservableCollection<PessoaAreaComumDTO> listaReservas = await 
            _request.GetAsync<ObservableCollection<PessoaAreaComumDTO>>(apiUrlBase + urlComplementar, _token);
            return listaReservas;
        }

        public async Task<int> DeletePessoaAreasAsync(int ReservaId)
        {
            string urlComplementar = string.Format("/{0}", ReservaId); var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token); return result;

        }

    }
#endregion
}
