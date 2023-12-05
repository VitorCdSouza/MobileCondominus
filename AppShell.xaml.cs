using TelaLogin.Views.Usuarios;
namespace TelaLogin;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        string login = Preferences.Get("UsuarioUsername", string.Empty);
        lblLogin.Text = $"Login: {login}";
    }
    private async void OnSairTapped(object sender, EventArgs e)
    {
        // Close the AppShell
        await Navigation.PushAsync(new LoginView());
    }
}
