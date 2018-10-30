using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;
using WCF.Contratos;
using WCF.Data.CRUD;
using WCF.FilaConsumidor.Interfaces;

namespace WCF.FilaConsumidor
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false)]
    public class UsuarioInboundMarketingMessageHandlerService : IUsuarioInboundMarketingMessageHandlerService
    {
        private readonly CRUD _dal;

        public UsuarioInboundMarketingMessageHandlerService()
        {
            _dal = new CRUD();
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessarMensagemDeEntrada(MsmqMessage<UsuarioInboundMarketing> incomingOrderMessage)
        {
            var usuarioRequest = incomingOrderMessage.Body;
            Console.WriteLine("-- Mensagem Recebida --");
            Console.WriteLine(usuarioRequest.ID);
            Console.WriteLine(usuarioRequest.Nome);
            Console.WriteLine(usuarioRequest.Sobrenome);
            Console.WriteLine(usuarioRequest.Email);
            Console.WriteLine("-- Fim da mensagem --");


            _dal.Gravar(new Data.DbModel.UsuarioInboundMarketing()
            {
                Nome = usuarioRequest.Nome,
                Sobrenome = usuarioRequest.Sobrenome,
                Email = usuarioRequest.Email
            });
        }
    }
}
