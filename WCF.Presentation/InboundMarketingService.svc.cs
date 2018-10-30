using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WCF.Contratos;
using WCF.Presentation.Interfaces;

namespace WCF.Presentation
{
    public class InboundMarketingService : IInboundMarketingService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<bool> PostUsuarioInboundMarketing(UsuarioInboundMarketing usuarioInboundMarketing)
        {
            var requisicao = await _httpClient.PostAsync("http://localhost:49536/InboundMarketing.svc/Usuario", new StringContent(JsonConvert.SerializeObject(usuarioInboundMarketing), Encoding.UTF8, "text/plain"));
            var resposta = await requisicao.Content.ReadAsStringAsync();
            return Convert.ToBoolean(resposta);
        }

        public async Task<List<UsuarioInboundMarketing>> GetUsuariosInboundMarketing()
        {
            var requisicao = await _httpClient.GetAsync("http://localhost:49536/InboundMarketing.svc/Usuarios");
            var resposta = await requisicao.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UsuarioInboundMarketing>>(resposta);
        }
    }
}
