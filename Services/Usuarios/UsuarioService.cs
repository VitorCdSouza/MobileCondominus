using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelaLogin.Models;

namespace TelaLogin.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://26.155.159.147:5237/Usuarios";

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u, string cpf)
        {
            string urlComplementar = "/Registrar?cpf=" + cpf;
            u.IdUsuario = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }
    }
}
