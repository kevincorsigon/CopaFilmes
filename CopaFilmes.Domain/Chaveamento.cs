using CopaFilmes.Domain.ListExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Domain
{
    public class Chaveamento
    {
        public Chaveamento(IEnumerable<Filme> filmesParticipantes)
        {
            OrganizaPartidas(filmesParticipantes);
        }

        public List<Partida> PartidasRestantes { get; set; }

        private void OrganizaPartidas(IEnumerable<Filme> filmesParticipantes)
        {
            var filmes = new List<Filme>();
            var partidas = new List<Partida>();
            filmes.AddRange(filmesParticipantes.OrderBy(d => d.Titulo));

            while (filmes.Any())
            {
                partidas.Add(new Partida(filmes.First(), filmes.Last()));
                filmes.Remove(filmes.First());
                filmes.Remove(filmes.Last());
            }

            PartidasRestantes = partidas;
        }      
    } 
}
