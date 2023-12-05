using TelaLogin.ViewModels.Dependentes;

namespace TelaLogin.Views.Dependentes;

public partial class DependenteView : ContentPage
{
    DependenteViewModel DependenteViewModel;
	public DependenteView()
	{
		InitializeComponent();
        DependenteViewModel = new DependenteViewModel();
        BindingContext = DependenteViewModel;
	}
    private async void OnButtonClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new DependenteCadView());

    }
}