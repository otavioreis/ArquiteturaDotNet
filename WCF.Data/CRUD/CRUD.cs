using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.Data.DbModel;

namespace WCF.Data.CRUD
{
    public class CRUD
    {
        public IEnumerable<UsuarioInboundMarketing> Listar()
        {
            dbEntities context = new dbEntities();

            IEnumerable<UsuarioInboundMarketing> lista = from p in context.UsuarioInboundMarketing select p;

            return lista;
        }

        public void Gravar(UsuarioInboundMarketing usuario)
        {
            try
            {
                dbEntities context = new dbEntities();

                context.UsuarioInboundMarketing.Add(usuario);

                context.SaveChanges();
            }
            catch (Exception e)
            {
                string resultado = e.ToString();
            }
        }
    }
}
