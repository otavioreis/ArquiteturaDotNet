using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WCF.Contratos;

namespace WCF.Presentation.Interfaces
{
    [ServiceContract]
    public interface IInboundMarketingService
    {

        [OperationContract]
        Task<bool> PostUsuarioInboundMarketing(UsuarioInboundMarketing usuarioInboundMarketing);


        [OperationContract]
        Task<List<UsuarioInboundMarketing>> GetUsuariosInboundMarketing();
    }
}
