using TelaLogin.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TelaLogin.Services.Dependentes;

namespace TelaLogin.ViewModels.Dependentes
{

    public class DependenteViewModel : BaseViewModel
    {
        private DependentesService aService;
        public ICommand ObterCommand { get; set; }

        public ICommand PostDependenteCommand {  get; set; }

        public ObservableCollection<DependenteDTO> Dependentes { get; set; }

        public void InicializarCommands()
        {
            PostDependenteCommand = new Command(async () => await PostDependente());

            ObterCommand = new Command(async () => await ObterDependentes());
        }

        public DependenteViewModel() 
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            aService = new DependentesService(token); //Mudar para tokenUsuario 
            Dependentes = new ObservableCollection<DependenteDTO>();
            _ = ObterDependentes();

            InicializarCommands();
        }

        #region AtributosPropiedades
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

        private string nomeDependenteDTO = string.Empty;
        public string NomeDependenteDTO
        {
            get { return nomeDependenteDTO; }
            set
            {
                nomeDependenteDTO = value;
                OnPropertyChanged();
            }
        }

        private string cpfDependenteDTO = string.Empty;
        public string CpfDependenteDTO
        {
            get { return cpfDependenteDTO; }
            set
            {
                cpfDependenteDTO = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public async Task PostDependente()
        {
            try
            {
                Dependente a = new Dependente();
                a.NomeDependente = NomeDependenteDTO;
                a.CpfDependente = CpfDependenteDTO;

                string asd = await aService.PostDependenteAsync(a);
                string mensagem = $"Dependente realizado com sucesso!";
                await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", "Dependente realizado com sucesso!", "Ok");
            }
        }


        public async Task ObterDependentes()
        {
            try
            {
                Dependentes = await aService.GetDependentesAsync();
               OnPropertyChanged(nameof(Dependentes));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", "Erro ao obter Dependentes: " + ex.Message, "Ok");
                
            }
        }

        public async Task ExcluirDependente(int DependenteId)
        {
            try
            {
                int resultado = await aService.DeleteDependenteAsync(DependenteId);
                await Application.Current.MainPage.DisplayAlert("Informação", "Dependente excluído com sucesso!", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", "Erro ao excluir Dependente: " + ex.Message, "Ok");
            }
        }
    }
}