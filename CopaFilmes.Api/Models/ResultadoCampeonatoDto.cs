using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Models
{
    public class ResultadoCampeonatoDto
    {
        public FilmeDto Campeao { get; set; }

        public FilmeDto ViceCampeao { get; set; }
    }
}
