using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TelaLogin.Services.PessoasAreas;
using TelaLogin.Models;

namespace TelaLogin.ViewModels.PessoasAreas
{
    public class PessoasAreasViewModel : BaseViewModel
    {
        private PessoasAreasService rService;
        public ICommand ObterCommand { get; set; }
        public ObservableCollection<PessoaAreaComumDTO> Pessoas { get; set; }
        public List<string> AreasComunsStr { get; set; }
        public string AreaSelecionada { get; set; }

        public void InicializarCommands()
        {
            ObterCommand = new Command(async () => await ObterPessoasAreas());
        }
        public PessoasAreasViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            rService = new PessoasAreasService(token);
            Pessoas = new ObservableCollection<PessoaAreaComumDTO>();
            AreasComunsStr = new List<string>();
            _ = ObterAreas();
            _ = ObterPessoasAreas();

            InicializarCommands();
        }

        #region AtributosPropriedades
        private List<string> areasComuns;
        public List<string> AreasComuns
        {
            get { return areasComuns; }
            set
            {
                areasComuns = value;
                OnPropertyChanged();
            }
        }

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

        private string nomeAreaPessAreaDTO;
        public string NomeAreaPessAreaDTO
        {
            get { return nomeAreaPessAreaDTO; }
            set
            {
                nomeAreaPessAreaDTO = value;
                OnPropertyChanged();
            }
        }

        private DateTime dataHoraInicioPessAreaDTO;
        public DateTime DataHoraInicioPessAreaDTO
        {
            get { return dataHoraInicioPessAreaDTO; }
            set
            {
                dataHoraInicioPessAreaDTO = value;
                OnPropertyChanged();
            }
        }

        private DateTime dataHoraFimPessAreaDTO;
        public DateTime DataHoraFimPessAreaDTO
        {
            get { return dataHoraFimPessAreaDTO; }
            set
            {
                dataHoraFimPessAreaDTO = value;
                OnPropertyChanged();
            }
        }

        private string nomePessoaDTO;
        public string NomePessoaDTO
        {
            get { return nomePessoaDTO; }
            set
            {
                nomePessoaDTO = value;
                OnPropertyChanged();
            }
        }

        private int idPessoaPessAreaDTO;
        public int IdPessoaPessAreaDTO
        {
            get { return idPessoaPessAreaDTO; }
            set
            {
                idPessoaPessAreaDTO = value;
                OnPropertyChanged();
            }
        }

        private int idAreaComumPessAreaDTO;
        public int IdAreaComumPessAreaDTO
        {
            get { return idAreaComumPessAreaDTO; }
            set
            {
                idAreaComumPessAreaDTO = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public async Task ObterAreas()
        {
            try
            {
                AreasComunsStr = await rService.GetAreasComunsAsync();
                OnPropertyChanged(nameof(Pessoas));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Erro ao obter Pessoas: " + ex.Message, "Ok");
            }
        }
        public async Task ObterPessoasAreas()
        {
            try
            {
                Pessoas = await rService.GetPessoasAreasComunsAsync();
                OnPropertyChanged(nameof(Pessoas));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Erro ao obter Pessoas: " + ex.Message, "Ok");
            }
        }

        public async Task PostReserva(PessoaAreaComumDTO pessoa)
        {
            try
            {
                PessoaAreaComumDTO pessoaRes = await rService.PostPessoaAreasAsync(pessoa);
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Reserva realizada com sucesso!", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Erro ao realizar reserva: " + ex.Message, "Ok");
            }
        }

        public async Task ExcluirReserva(int reservaId)
        {
            try
            {
                int resultado = await rService.DeletePessoaAreasAsync(reservaId);
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Reserva excluída com sucesso!", "Ok");
                _ = ObterPessoasAreas(); // Recarregar a lista de Pessoas após exclusão, se necessário
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", "Erro ao excluir reserva: " + ex.Message, "Ok");
            }
        }
    }
}
