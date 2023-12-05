using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelaLogin.Models;
namespace TelaLogin.Services.Encomendas
{
    public class EncomendasRetiradasService : Request
    {

        private readonly Request _request;
        private const string apiUrlBase = "http://26.155.159.147:5237/Entregas";

        private string _token;
        public EncomendasRetiradasService(string token)
        {
            _request = new Request();
            _token = token; //mudar para tokenUsuario
        }
        #region metodos

        public async Task<EntregaDTO> PostEntregaAsync(EntregaDTO r)
        {
            return await _request.PostAsync(apiUrlBase, r, _token);
        }

        

        public async Task<ObservableCollection<EntregaDTO>> GetEntregasReAsync()

        {

            try

            {

                string urlComplementar = "/GetAllCondominioMorador";

                ObservableCollection<EntregaDTO> listaEntregas = await _request.GetAsync<ObservableCollection<EntregaDTO>>(apiUrlBase + urlComplementar, _token);

                // Filtra as entregas onde o campo DataRetirada é nulo

                var entregasNNulas = listaEntregas.Where(entrega => entrega.DataRetiradaEntDTO != null).ToList();

                // Cria uma nova ObservableCollection apenas com as entregas filtradas

                ObservableCollection<EntregaDTO> resultado = new ObservableCollection<EntregaDTO>(entregasNNulas);

                return resultado;

            }

            catch (Exception ex)

            {

                await Application.Current.MainPage.DisplayAlert("Informação", "Erro ao obter entregas: " + ex.Message, "Ok");

                // Retorna uma nova ObservableCollection<Entrega>() em caso de erro

                return new ObservableCollection<EntregaDTO>();

            }
        }

            public async Task<int> DeleteEntregaAsync(int EntregaId)
        {
            string urlComplementar = string.Format("/{0}", EntregaId); var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token); return result;

        }
        #endregion
    }
}
