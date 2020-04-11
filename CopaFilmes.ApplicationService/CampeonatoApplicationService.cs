using CopaFilmes.ApplicationService.Interfaces;
using CopaFilmes.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CopaFilmes.ApplicationService
{
    public class CampeonatoApplicationService : ICampeonatoApplicationService
    {
        public Campeonato RealizaCampeonato(IEnumerable<Filme> filmesParticipantes)
        {
            if (filmesParticipantes.Count() != 8)
            {
                throw new Exception("São esperados 8 times para a realização de um campeonato.");
            }

            var campeonato = new Campeonato(filmesParticipantes);
            campeonato.IniciaDisputa();
            return campeonato;
        }
    }
}
