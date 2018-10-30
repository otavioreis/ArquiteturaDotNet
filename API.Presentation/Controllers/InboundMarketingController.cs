using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API.Presentation.ObjectModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InboundMarketingController : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        [HttpPost]
        [Route("usuario")]
        public async Task<IActionResult> PostUsuarioInboundMarketing([FromBody] UsuarioInboundMarketing usuarioInboundMarketing)
        {
            var requisicao = await _httpClient.PostAsync("http://localhost:49536/InboundMarketing.svc/Usuario", new StringContent(JsonConvert.SerializeObject(usuarioInboundMarketing), Encoding.UTF8, "text/plain"));
            var resposta = await requisicao.Content.ReadAsStringAsync();
            return Ok(Convert.ToBoolean(resposta));
        }

        [HttpGet]
        [Route("usuarios")]
        public async Task<IActionResult> GetUsuariosInboundMarketing()
        {
            var requisicao = await _httpClient.GetAsync("http://localhost:49536/InboundMarketing.svc/Usuarios");
            var resposta = await requisicao.Content.ReadAsStringAsync();
            return Ok(JsonConvert.DeserializeObject<List<UsuarioInboundMarketing>>(resposta));
        }


    }
}