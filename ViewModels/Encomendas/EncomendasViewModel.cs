using TelaLogin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TelaLogin.Services.Encomendas;

namespace TelaLogin.ViewModels.Encomendas
{
    public class EncomendasViewModel : BaseViewModel
    {
        private EncomendaService rService;
        private EncomendasRetiradasService erService;
        public ICommand ObterCommand { get; set; }
        public ICommand ObterReCommand { get; set; }
        public ObservableCollection<EntregaDTO> Entregas { get; set; }
        public ObservableCollection<EntregaDTO> EntregasRe { get; set; }

        public void InicializarCommands()
        {
            ObterCommand = new Command(async () => await ObterEntregas());
            ObterReCommand = new Command(async () => await ObterEntregasRe());
        }

        public EncomendasViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            rService = new EncomendaService(token); //Mudar para tokenUsuario 
            erService = new EncomendasRetiradasService(token);
            Entregas = new ObservableCollection<EntregaDTO>();
            EntregasRe = new ObservableCollection<EntregaDTO>();
            _ = ObterEntregas();
            _ = ObterEntregasRe();
            InicializarCommands();
        }
        #region AtributosPropriedades

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string destinatarioEntDTO;
        public string DestinatarioEntDTO
        {
            get { return destinatarioEntDTO; }
            set
            {
                destinatarioEntDTO = value;
                OnPropertyChanged();
            }
        }

        private string numeroApartDTO;
        public string NumeroApartDTO
        {
            get { return numeroApartDTO; }
            set
            {
                numeroApartDTO = value;
                OnPropertyChanged();
            }
        }

        private DateTime? dataEntregaEntDTO;
        public DateTime? DataEntregaEntDTO
        {
            get { return dataEntregaEntDTO; }
            set
            {
                dataEntregaEntDTO = value;
                OnPropertyChanged();
            }
        }

        private DateTime? dataRetiradaEntDTO;
        public DateTime? DataRetiradaEntDTO
        {
            get { return dataRetiradaEntDTO; }
            set
            {
                dataRetiradaEntDTO = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Metodos

        public async Task ObterEntregas()
        {
            try
            {
               Entregas = await rService.GetEntregasAsync();

                // Lógica de manipulação dos dados recebidos, se necessário
               OnPropertyChanged(nameof(Entregas));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Erro ao obter Entregas: " + ex.Message, "Ok");

            }
        }

        public async Task ObterEntregasRe()
        {
            try
            {
                EntregasRe = await erService.GetEntregasReAsync();

                // Lógica de manipulação dos dados recebidos, se necessário
                OnPropertyChanged(nameof(EntregasRe));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Erro ao obter Entregas: " + ex.Message, "Ok");
                // Retorne uma coleção vazia ou null, dependendo da sua lógica de tratamento de erros
            }
        }


        #endregion
    }
}
