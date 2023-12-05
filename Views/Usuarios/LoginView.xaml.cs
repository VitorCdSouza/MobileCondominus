using TelaLogin.ViewModels.Usuarios;
using TelaLogin.Views;
using TelaLogin.Views.Cadastro;
namespace TelaLogin.Views.Usuarios;

public partial class LoginView : ContentPage
{
	UsuarioViewModel usuarioViewModel;
	public LoginView()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        usuarioViewModel = new UsuarioViewModel();
		BindingContext = usuarioViewModel;
	}
    private async void OnLabelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastrarView());

    }

}