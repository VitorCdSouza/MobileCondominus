using TelaLogin.ViewModels.Usuarios;

namespace TelaLogin.Views.Comunicacao;

public partial class FeedBackView : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public FeedBackView()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;
    }
}