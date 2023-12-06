using TelaLogin.ViewModels.PessoasAreas;

namespace TelaLogin.Views.PessoasAreas;

public partial class PessoasAreasFzView : ContentPage
{
    PessoasAreasViewModel pessoaAreasViewModel;
    public PessoasAreasFzView()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        datePicker.MinimumDate = DateTime.Now;
        pessoaAreasViewModel = new PessoasAreasViewModel();
        BindingContext = pessoaAreasViewModel;
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PessoasAreasView());

    }
    public System.TimeSpan Time { get; set; }

}