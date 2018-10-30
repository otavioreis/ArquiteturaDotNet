using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;
using WCF.Contratos;

namespace WCF.FilaConsumidor.Interfaces
{
    [ServiceContract]
    [ServiceKnownType(typeof(UsuarioInboundMarketing))]
    public interface IUsuarioInboundMarketingMessageHandlerService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void ProcessarMensagemDeEntrada(MsmqMessage<UsuarioInboundMarketing> incomingOrderMessage);
    }
}
