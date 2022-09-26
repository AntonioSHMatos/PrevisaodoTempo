using Microsoft.AspNetCore.Mvc;
using PrevisaoDoTempo.Modelo;
using PrevisaoDoTempo.Negocio.PrevisaoDoTempo;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ModelState = System.Web.Http.ModelBinding.ModelState;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PrevisaoDoTempo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoDoTempoController : ControllerBase
    {
        private readonly IPrevisaoDoTempo _previsaoDoTempo;

        public PrevisaoDoTempoController(IPrevisaoDoTempo previsaoDoTempo)
        {
            _previsaoDoTempo = previsaoDoTempo;
        }

        [HttpPost]
        public async Task Incluir([FromBody] Previsao previsao)
        {
            previsao.DataHoraPrevisao = DateTime.Now;
            {
                if (ModelState.IsValid)
                {
                    await _previsaoDoTempo.Incluir(previsao);
                }
            }

        }

        [HttpGet]
        public async Task<List<Previsao>> Get() => await _previsaoDoTempo.ObterLista();
    }
}