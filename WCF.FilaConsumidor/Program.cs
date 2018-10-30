using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.FilaConsumidor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(UsuarioInboundMarketingMessageHandlerService)))
            {
                host.Faulted += host_Faulted;
                host.Open();
                Console.WriteLine("O serviço está pronto");
                Console.WriteLine("Aperte <ENTER> para terminar o serviço");
                Console.ReadLine();
                if (host.State == CommunicationState.Faulted)
                {
                    host.Abort();
                }

                host.Close();
            }
        }

        static void host_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Erro!");
        }
    }
}
