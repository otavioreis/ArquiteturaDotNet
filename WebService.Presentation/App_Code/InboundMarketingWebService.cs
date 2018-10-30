using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Services;
using Newtonsoft.Json;
using WCF.Contratos;

/// <summary>
/// Summary description for InboundMarketingWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class InboundMarketingWebService : System.Web.Services.WebService
{
    private static readonly HttpClient _httpClient = new HttpClient();

    [WebMethod]
    public bool PostUsuarioInboundMarketing(string nome, string sobrenome, string email)
    {
        var usuarioInboundMarketing = new UsuarioInboundMarketing()
        {
            Nome = nome,
            Sobrenome = sobrenome,
            Email = email
        };

        var requisicao = _httpClient.PostAsync("http://localhost:49536/InboundMarketing.svc/Usuario", new StringContent(JsonConvert.SerializeObject(usuarioInboundMarketing), Encoding.UTF8, "text/plain")).Result;
        var resposta = requisicao.Content.ReadAsStringAsync().Result;
        return Convert.ToBoolean(resposta);
    }

    [WebMethod]
    public List<UsuarioInboundMarketing> GetUsuariosInboundMarketing()
    {
        var requisicao = _httpClient.GetAsync("http://localhost:49536/InboundMarketing.svc/Usuarios").Result;
        var resposta = requisicao.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<List<UsuarioInboundMarketing>>(resposta);
    }

}
