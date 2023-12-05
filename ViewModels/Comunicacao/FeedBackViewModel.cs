using TelaLogin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TelaLogin.Services.Comunicacao;

namespace TelaLogin.ViewModels.Comunicacao
{
    public class FeedBackViewModel : BaseViewModel
    {
        private FeedBackService fService;
        public ICommand ObterCommand { get; set; }
        public ObservableCollection<FeedBack> FeedBack { get; set; }

        public FeedBackViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            fService = new FeedBackService(token); //Mudar para tokenUsuario 
            FeedBack = new ObservableCollection<FeedBack>();
        }


        #region Metodos
        public async Task PostEntrega(FeedBack FeedBack)
        {
            try
            {
                // Faça as adaptações necessárias para configurar a Entrega antes de enviar
                FeedBack FeedBackEnviado = await fService.PostFeedBackAsync(FeedBack);

                // Lógica de manipulação do resultado, se necessário
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Entrega realizada com sucesso!", "Ok");

                // Atualize a lógica conforme necessário, por exemplo, navegando para uma página de detalhes de Entrega
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Erro ao realizar Entrega: " + ex.Message, "Ok");
            }
        }

        #endregion
    }
}
