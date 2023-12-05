using TelaLogin.ViewModels.Encomendas;

namespace TelaLogin.Views.Encomendas;

public partial class EncomendasView : ContentPage
{
    EncomendasViewModel encomendasViewModel;
    public EncomendasView()
	{
		InitializeComponent();

        NavigationPage.SetHasNavigationBar(this, false);

        encomendasViewModel = new EncomendasViewModel();
        BindingContext = encomendasViewModel;
    }
}