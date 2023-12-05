using TelaLogin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TelaLogin.Services.Comunicacao;

namespace TelaLogin.ViewModels.Avisos
{
    public class AvisosViewModel : BaseViewModel
    {
        private AvisosService aService;
        public ICommand ObterCommand { get; set; }
        public ObservableCollection<NotificacaoDTO> Avi { get; set; }


        public void InicializarCommands()
        {
            ObterCommand = new Command(async () => await ObterAvisos());
        }

        public AvisosViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            aService = new AvisosService(token); //Mudar para tokenUsuario 
            Avi = new ObservableCollection<NotificacaoDTO>();

            _ =ObterAvisos();
            InicializarCommands();
        }

        #region AtributosPropiedades
        private int idNotificacaoDTO;  
        public int IdNotificacaoDTO
        {
            get { return idNotificacaoDTO; }
            set
            {
                idNotificacaoDTO = value;
                OnPropertyChanged();
            }
        }

        private string assuntoNotificacaoDTO = string.Empty;
        public string AssuntoNotificacaoDTO
        {
            get { return assuntoNotificacaoDTO; }
            set
            {
                assuntoNotificacaoDTO = value;
                OnPropertyChanged();
            }
        }

        private string mensagemNotificacaoDTO = string.Empty;
        public string MensagemNotificacaoDTO
        {
            get { return mensagemNotificacaoDTO; }
            set
            {
                mensagemNotificacaoDTO = value;
                OnPropertyChanged();
            }
        }

        private DateTime dataEnvioNotificacaoDTO;
        public DateTime DataEnvioNotificacaoDTO
        {
            get { return dataEnvioNotificacaoDTO; }
            set
            {
                dataEnvioNotificacaoDTO = value;
                OnPropertyChanged();
            }
        }

        
        #endregion
        #region Metodos
        public async Task ObterAvisos()
        {
            try
            {
                Avi  = await aService.GetAvisosAsync();
                OnPropertyChanged(nameof(Avi));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Erro ao obter Avisos: " + ex.Message, "Ok");
            }
        }

        #endregion
    }
}
