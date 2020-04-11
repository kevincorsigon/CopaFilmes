using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Domain
{
    public class Partida
    {
        public Partida(Filme a, Filme b)
        {
            ParticipanteA = a;
            ParticipanteB = b;
        }

        public Filme ParticipanteA { get; set; }

        public Filme ParticipanteB { get; set; }

        public Filme IdentificaGanhador() 
        {
            var filmes = new List<Filme> { ParticipanteA, ParticipanteB };

            if (ParticipanteA.Nota == ParticipanteB.Nota)
            {
                return filmes.OrderBy(d => d.Titulo).FirstOrDefault();
            }

            return filmes.OrderByDescending(d => d.Nota).FirstOrDefault();
        }
    }
}
