using CopaFilmes.Api.Models;
using CopaFilmes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Extensions
{
    public static class MapperExtensions
    {
        public static FilmeDto ToDto(this Filme obj)
        {
            return new FilmeDto
            {
                Id = obj.Id,
                Ano = obj.Ano,
                Nota = obj.Nota,
                Titulo = obj.Titulo
            };
        }

        public static Filme ToDomain(this FilmeDto obj)
        {
            return new Filme
            {
                Id = obj.Id,
                Ano = obj.Ano,
                Nota = obj.Nota,
                Titulo = obj.Titulo
            };
        }

        public static IEnumerable<FilmeDto> ToDto(this IEnumerable<Filme> obj)
        {
            foreach (var item in obj)
            {
                yield return new FilmeDto
                {
                    Id = item.Id,
                    Ano = item.Ano,
                    Nota = item.Nota,
                    Titulo = item.Titulo
                };
            }
        }

        public static IEnumerable<Filme> ToDomain(this IEnumerable<FilmeDto> obj)
        {
            foreach (var item in obj)
            {
                yield return new Filme
                {
                    Id = item.Id,
                    Ano = item.Ano,
                    Nota = item.Nota,
                    Titulo = item.Titulo                   
                };
            }
        }


    }
}
