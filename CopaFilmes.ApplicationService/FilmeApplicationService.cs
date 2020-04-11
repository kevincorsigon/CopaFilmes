using CopaFilmes.ApplicationService.Interfaces;
using CopaFilmes.Domain;
using CopaFilmes.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.ApplicationService
{
    public class FilmeApplicationService : IFilmeApplicationService
    {
        #region Construtor
        public FilmeApplicationService(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }
        #endregion

        #region Atributos
        private readonly IFilmeService _filmeService;
        #endregion

        #region Métodos
        public Task<IEnumerable<Filme>> ListaFilmesDisponiveis()
        {
            return _filmeService.GetFilmesAsync();
        }
        #endregion
    }
}
