using CopaFilmes.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.ApplicationService.Interfaces
{
    public interface ICampeonatoApplicationService
    {
        Campeonato RealizaCampeonato(IEnumerable<Filme> filmesParticipantes);
    }
}
