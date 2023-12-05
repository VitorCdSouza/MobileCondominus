using TelaLogin.ViewModels.PessoasAreas;


namespace TelaLogin.Views.PessoasAreas;

public partial class PessoasAreasView : ContentPage
{
    PessoasAreasViewModel pessoaAreasViewModel;
    public PessoasAreasView()
	{
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        pessoaAreasViewModel = new PessoasAreasViewModel();
        BindingContext = pessoaAreasViewModel;
    }
    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PessoasAreasFzView());

    }
}