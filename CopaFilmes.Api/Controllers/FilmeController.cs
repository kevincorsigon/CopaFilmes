using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Api.Extensions;
using CopaFilmes.Api.Models;
using CopaFilmes.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeApplicationService _filmeAppService;
        public FilmeController(IFilmeApplicationService filmeAppService)
        {
            _filmeAppService = filmeAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeDto>>> Get()
        {
            try
            {
                var filmes = await _filmeAppService.ListaFilmesDisponiveis();
                return Ok(new
                {
                    result = filmes.ToDto(),
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