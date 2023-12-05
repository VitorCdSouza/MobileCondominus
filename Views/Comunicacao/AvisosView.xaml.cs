using TelaLogin.ViewModels.Avisos;
using TelaLogin.ViewModels.Usuarios;

namespace TelaLogin.Views.Comunicacao;

public partial class AvisosView : ContentPage
{
    AvisosViewModel avisoViewModel;
    public AvisosView()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        avisoViewModel = new AvisosViewModel();
        BindingContext = avisoViewModel;
    }
}