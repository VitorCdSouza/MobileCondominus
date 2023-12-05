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
}