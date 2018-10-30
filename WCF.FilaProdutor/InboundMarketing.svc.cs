using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Transactions;
using Newtonsoft.Json;
using WCF.Contratos;
using WCF.Data.CRUD;
using WCF.FilaProdutor.Interfaces;

namespace WCF.FilaProdutor
{
    public class InboundMarketingService : IInboundMarketingService
    {
        private readonly CRUD _dal;

        public InboundMarketingService()
        {
            _dal = new CRUD();
        }

        public bool PostUsuarioInboundMarketing(System.IO.Stream stream)
        {
            try
            {
                string strUsuarioInboundMarketing;

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    strUsuarioInboundMarketing = reader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(strUsuarioInboundMarketing))
                {
                    var usuarioInboundMarketing = JsonConvert.DeserializeObject<UsuarioInboundMarketing>(strUsuarioInboundMarketing);

                    var queue = new MessageQueue(ConfigurationManager.AppSettings["MessageQueuePath"]);

                    var msg = new Message { Body = usuarioInboundMarketing };

                    using (var ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        queue.Send(msg, MessageQueueTransactionType.Automatic);
                        ts.Complete();
                    }

                    Debug.WriteLine("Mensagem Enviada");

                    return true; 
                }


                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<UsuarioInboundMarketing> GetUsuariosInboundMarketing()
        {
            var listaUsuarios = _dal.Listar().ToList();
            var listaUsuariosRetorno = new List<UsuarioInboundMarketing>();

            foreach (var usuario in listaUsuarios)
            {
                listaUsuariosRetorno.Add(new UsuarioInboundMarketing()
                {
                    ID = usuario.ID,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    Email = usuario.Email
                });
            }

            return listaUsuariosRetorno;
        }
    }
}
