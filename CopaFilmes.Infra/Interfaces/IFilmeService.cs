using CopaFilmes.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.Infra
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> GetFilmesAsync();
    }
}
