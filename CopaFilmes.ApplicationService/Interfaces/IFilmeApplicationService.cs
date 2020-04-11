using CopaFilmes.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.ApplicationService.Interfaces
{
    public interface IFilmeApplicationService
    {
        Task<IEnumerable<Filme>> ListaFilmesDisponiveis();
    }
}
