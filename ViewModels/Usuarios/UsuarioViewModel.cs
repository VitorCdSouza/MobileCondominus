    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelaLogin.Services.Usuarios;
using System.Windows.Input;
using TelaLogin.Views.Usuarios;
using TelaLogin.Models;

namespace TelaLogin.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }

        public void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            AutenticarCommand = new Command(async () =>
            {
                await AutenticarUsuario();
            });
        }

        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            InicializarCommands();
        }




        #region AtributosPropiedades

        private string emailUsuario = "admin@gmail.com";
        public string EmailUsuario { 
            get { return emailUsuario; } 
            set {
                emailUsuario = value;
                OnPropertyChanged();
            } 
        }

        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }
        private string senhaUsuario = "123456";
        public string SenhaUsuario { 
            get { return senhaUsuario; } 
            set {
                senhaUsuario = value; 
                OnPropertyChanged(); 
            } 
        }

        private string cpf = string.Empty;
        public string Cpf
        {
            get { return cpf; }
            set
            {
                cpf = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Metodos
        public async Task RegistrarUsuario()
        { 
            try
            {
                Usuario u = new Usuario();
                u.EmailUsuario = EmailUsuario; // mudar para EmailUsuario
                u.SenhaUsuario = SenhaUsuario;// mudar para SenhaUsuario
                Usuario uRegistrado = await uService.PostRegistrarUsuarioAsync(u, Cpf);

                if (uRegistrado.IdUsuario != 0) 
                { 
                    string mensagem = $"Usuário  {uRegistrado.EmailUsuario} registrado com sucesso!";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage
                        .Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.EmailUsuario = EmailUsuario; // mudar para EmailUsuario
                u.SenhaUsuario = SenhaUsuario;// mudar para SenhaUsuario

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.TokenUsuario)) 
                {
                    Preferences.Set("UsuarioId", uAutenticado.IdUsuario);// Id da Pessoa
                    Preferences.Set("UsuarioNome", uAutenticado.PessoaUsuario.NomePessoa); //Mudar para Email
                    //Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);
                    Preferences.Set("UsuarioToken", uAutenticado.TokenUsuario);

                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :(", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes " + ex.InnerException, "Ok");
            }


        }
        #endregion
    }
}
