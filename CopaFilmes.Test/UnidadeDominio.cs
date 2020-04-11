using CopaFilmes.Domain;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace CopaFilmes.Test
{
    /// <summary>
    /// Objetivo desses testes é validar se as regras de negocio presentes no domínio da aplicação estão sendo atendidas
    /// </summary>
    public class UnidadeDominio
    {
        [Fact]
        public void ValidaGanhadorPartidaMaiorNota()
        {
            var filme1 = new Filme() { Id = "1", Nota = 1 };
            var filme2 = new Filme() { Id = "2", Nota = 2 };
            var partida = new Partida(filme1, filme2);
            var ganhador = partida.IdentificaGanhador();
            Assert.True(ganhador.Id == "2");
        }

        [Fact]
        public void ValidaGanhadorPartidaNotaIgualPorNome()
        {
            var filme1 = new Filme() { Id = "a", Nota = 1 };
            var filme2 = new Filme() { Id = "b", Nota = 1 };
            var partida = new Partida(filme1, filme2);
            var ganhador = partida.IdentificaGanhador();
            Assert.True(ganhador.Id == "a");
        }

        [Fact]
        public void ValidaChaveamentoPartidasOrdenadasAlfabeticamente()
        {
            var filme1 = new Filme() { Id = "1", Titulo = "1", Nota = 1 };
            var filme2 = new Filme() { Id = "2", Titulo = "2", Nota = 2 };
            var filme3 = new Filme() { Id = "3", Titulo = "3", Nota = 3 };
            var filme4 = new Filme() { Id = "4", Titulo = "4", Nota = 4 };
            var filme5 = new Filme() { Id = "5", Titulo = "5", Nota = 5 };
            var filme6 = new Filme() { Id = "6", Titulo = "6", Nota = 6 };
            var filme7 = new Filme() { Id = "7", Titulo = "7", Nota = 7 };
            var filme8 = new Filme() { Id = "8", Titulo = "8", Nota = 8 };

            var lista = new List<Filme> { filme5, filme8, filme1, filme2, filme3, filme6, filme7, filme4 };

            var chaveamento = new Chaveamento(lista);

            Assert.True(
                chaveamento.PartidasRestantes.FirstOrDefault().ParticipanteA.Id == filme1.Id &&
                chaveamento.PartidasRestantes.FirstOrDefault().ParticipanteB.Id == filme8.Id &&
                chaveamento.PartidasRestantes.LastOrDefault().ParticipanteA.Id == filme4.Id &&
                chaveamento.PartidasRestantes.LastOrDefault().ParticipanteB.Id == filme5.Id
                );
        }


        [Fact]
        public void ValidaChaveamentoQuantidadePartidas()
        {
            var filme1 = new Filme() { Id = "1", Titulo = "1", Nota = 1 };
            var filme2 = new Filme() { Id = "2", Titulo = "2", Nota = 2 };
            var filme3 = new Filme() { Id = "3", Titulo = "3", Nota = 3 };
            var filme4 = new Filme() { Id = "4", Titulo = "4", Nota = 4 };
            var filme5 = new Filme() { Id = "5", Titulo = "5", Nota = 5 };
            var filme6 = new Filme() { Id = "6", Titulo = "6", Nota = 6 };
            var filme7 = new Filme() { Id = "7", Titulo = "7", Nota = 7 };
            var filme8 = new Filme() { Id = "8", Titulo = "8", Nota = 8 };

            var lista = new List<Filme> { filme1, filme2, filme3, filme4, filme5, filme6, filme7, filme8 };

            var chaveamento = new Chaveamento(lista);

            Assert.True(chaveamento.PartidasRestantes.Count == 4);
        }


        [Fact]
        public void ValidaCampeaoMaiorNota()
        {
            var filme1 = new Filme() { Id = "1", Titulo = "1", Nota = 1 };
            var filme2 = new Filme() { Id = "2", Titulo = "2", Nota = 2 };
            var filme3 = new Filme() { Id = "3", Titulo = "3", Nota = 3 };
            var filme4 = new Filme() { Id = "4", Titulo = "4", Nota = 4 };
            var filme5 = new Filme() { Id = "5", Titulo = "5", Nota = 5 };
            var filme6 = new Filme() { Id = "6", Titulo = "6", Nota = 6 };
            var filme7 = new Filme() { Id = "7", Titulo = "7", Nota = 7 };
            var filme8 = new Filme() { Id = "8", Titulo = "8", Nota = 8 };

            var lista = new List<Filme> { filme1, filme2, filme3, filme4, filme5, filme6, filme7, filme8 };

            var campeonato = new Campeonato(lista);

            campeonato.IniciaDisputa();

            Assert.True(campeonato.Campeao.Id == filme8.Id);
        }

        [Fact]
        public void ValidaCampeaoNotaIgualAlfabetico()
        {
            var filme1 = new Filme() { Id = "1", Titulo = "1", Nota = 1 };
            var filme2 = new Filme() { Id = "2", Titulo = "2", Nota = 2 };
            var filme3 = new Filme() { Id = "3", Titulo = "3", Nota = 3 };
            var filme4 = new Filme() { Id = "4", Titulo = "4", Nota = 20 };
            var filme5 = new Filme() { Id = "5", Titulo = "5", Nota = 5 };
            var filme6 = new Filme() { Id = "6", Titulo = "6", Nota = 6 };
            var filme7 = new Filme() { Id = "7", Titulo = "7", Nota = 7 };
            var filme8 = new Filme() { Id = "8", Titulo = "8", Nota = 20 };

            var lista = new List<Filme> { filme1, filme2, filme3, filme4, filme5, filme6, filme7, filme8 };

            var campeonato = new Campeonato(lista);

            campeonato.IniciaDisputa();

            Assert.True(campeonato.Campeao.Id == filme4.Id);
        }

        [Fact]
        public void ValidaCampeaoNotaIgualAlfabeticoNotasIguais()
        {
            var filme1 = new Filme() { Id = "1", Titulo = "a", Nota = 1 };
            var filme2 = new Filme() { Id = "2", Titulo = "b", Nota = 1 };
            var filme3 = new Filme() { Id = "3", Titulo = "c", Nota = 1 };
            var filme4 = new Filme() { Id = "4", Titulo = "d", Nota = 1 };
            var filme5 = new Filme() { Id = "5", Titulo = "e", Nota = 1 };
            var filme6 = new Filme() { Id = "6", Titulo = "f", Nota = 1 };
            var filme7 = new Filme() { Id = "7", Titulo = "g", Nota = 1 };
            var filme8 = new Filme() { Id = "8", Titulo = "h", Nota = 1 };

            var lista = new List<Filme> { filme1, filme2, filme3, filme4, filme5, filme6, filme7, filme8 };

            var campeonato = new Campeonato(lista);

            campeonato.IniciaDisputa();

            Assert.True(campeonato.Campeao.Id == filme1.Id);
        }
    }
}
