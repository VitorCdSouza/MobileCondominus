using TelaLogin.ViewModels.Usuarios;
using TelaLogin.Views.Usuarios;
namespace TelaLogin.Views.Cadastro;

public partial class CadastrarView : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public CadastrarView()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;


    }
    private async void OnLabelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginView());

    }

}