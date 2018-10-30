using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WCF.Contratos;

namespace WCF.FilaProdutor.Interfaces
{
    [ServiceContract]
    public interface IInboundMarketingService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Usuario")]
        bool PostUsuarioInboundMarketing(System.IO.Stream stream);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Usuarios")]
        List<UsuarioInboundMarketing> GetUsuariosInboundMarketing();
    }
}
