using TelaLogin.ViewModels.Encomendas;

namespace TelaLogin.Views.Encomendas;

public partial class EncomendasRetiradasView : ContentPage
{
	public EncomendasRetiradasView()
	{
        EncomendasViewModel encomendasViewModel;
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        encomendasViewModel = new EncomendasViewModel();
        BindingContext = encomendasViewModel;
    }
}