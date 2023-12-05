using TelaLogin.ViewModels.Dependentes;
using TelaLogin.Services.Dependentes;

namespace TelaLogin.Views.Dependentes;

public partial class DependenteCadView : ContentPage
{
    DependenteViewModel DependenteViewModel;
	public DependenteCadView()
	{
		InitializeComponent();
        DependenteViewModel = new DependenteViewModel();
        BindingContext = DependenteViewModel;
    }
    private async void OnButtonClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new DependenteView());

    }

    private async void OnButtonClicked2(object sender, EventArgs e)
    {

        TelaLogin.Models.DependenteDTO a = new TelaLogin.Models.DependenteDTO();
        a.NomeDependenteDTO = "teste"; // mudar para EmailUsuario
        a.CpfDependenteDTO = "19192993"; //mudar para SenhaUsuario

        string token = Preferences.Get("UsuarioToken", string.Empty);
        DependentesService aService = new DependentesService(token);
        TelaLogin.Models.DependenteDTO DependenteEnviado = await aService.PostDependenteAsync(a);
        if (DependenteEnviado.Id != 0)
        {
            string mensagem = $"Dependente realizado com sucesso!";
            await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");
            // Possivelmente adicionaria alguma lógica adicional aqui, se necessário
        }

    }
}