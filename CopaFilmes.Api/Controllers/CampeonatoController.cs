using System;
using System.Threading.Tasks;
using CopaFilmes.Api.Extensions;
using CopaFilmes.Api.Models;
using CopaFilmes.ApplicationService.Interfaces;
using CopaFilmes.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonatoApplicationService _campeonatoApplicationService;
        public CampeonatoController(ICampeonatoApplicationService campeonatoApplicationService)
        {
            _campeonatoApplicationService = campeonatoApplicationService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseWrapper<ResultadoCampeonatoDto>>> RealizaCampeonato([FromBody]CampeonatoDto campeonato)
        {
            try
            {
                Campeonato campeonatoConcluido = null;

                await Task.Run(() =>
                {
                    campeonatoConcluido = _campeonatoApplicationService.RealizaCampeonato(campeonato.Filmes.ToDomain());
                });

                return Ok(new
                {
                    result = new ResultadoCampeonatoDto
                    {
                        Campeao = campeonatoConcluido.Campeao.ToDto(),
                        ViceCampeao = campeonatoConcluido.ViceCampeao.ToDto()
                    },
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}