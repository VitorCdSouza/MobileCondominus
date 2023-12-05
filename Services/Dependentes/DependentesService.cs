﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelaLogin.Models;

namespace TelaLogin.Services.Dependentes
{
    public class DependentesService
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://26.155.159.147:5237/Dependentes";

        private string _token;
        public DependentesService(string token)
        {
            _request = new Request();
            _token = token; //mudar para tokenUsuario
        }
        #region metodos

        public async Task<DependenteDTO> PostDependenteAsync(DependenteDTO a)
        {
            
            a = await _request.PostAsync(apiUrlBase, a, _token);
            return a;
        }
        public async Task<ObservableCollection<DependenteDTO>> GetDependentesAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAllCondominio");
            ObservableCollection<DependenteDTO> listaDependentes = await
            _request.GetAsync<ObservableCollection<DependenteDTO>>(apiUrlBase + urlComplementar, _token);
            return listaDependentes;
        }

        public async Task<int> DeleteDependenteAsync(int DependenteId)
        {
            string urlComplementar = string.Format("/{0}", DependenteId); var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token); return result;

        }
        #endregion
    }
}
