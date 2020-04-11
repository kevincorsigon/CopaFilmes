using CopaFilmes.Domain.ListExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Domain
{
    public class Campeonato
    {
        public Campeonato(IEnumerable<Filme> filmesParticipantes)
        {
            FilmesParticipantes = filmesParticipantes;
            Chaveamento = new Chaveamento(filmesParticipantes);
        }

        public IEnumerable<Filme> FilmesParticipantes { get; private set; }

        public Chaveamento Chaveamento { get; private set; }

        public Filme Campeao { get; private set; }

        public Filme ViceCampeao { get; private set; }

        public void IniciaDisputa()
        {
            while (Chaveamento.PartidasRestantes.Count % 2 == 0)
            {
                List<Partida> proximasPartidas = new List<Partida>();

                foreach (var item in Chaveamento.PartidasRestantes.DividePor(2))
                {
                    proximasPartidas.Add(new Partida(item.First().IdentificaGanhador(), item.Last().IdentificaGanhador()));
                }
                
                Chaveamento.PartidasRestantes = proximasPartidas;
            }

            Campeao = Chaveamento.PartidasRestantes.FirstOrDefault().IdentificaGanhador();
            ViceCampeao = Chaveamento.PartidasRestantes.FirstOrDefault().ParticipanteA.Id == Campeao.Id ? Chaveamento.PartidasRestantes.FirstOrDefault().ParticipanteB : Chaveamento.PartidasRestantes.FirstOrDefault().ParticipanteA;
        }
    }
}
