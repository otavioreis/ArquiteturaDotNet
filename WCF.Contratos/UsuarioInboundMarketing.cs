using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Contratos
{
    [DataContract]
    public class UsuarioInboundMarketing
    {
        [DataMember(IsRequired = true)]
        public int ID { get; set; }

        [DataMember(IsRequired = true)]
        public string Nome { get; set; }

        [DataMember(IsRequired = true)]
        public string Sobrenome { get; set; }

        [DataMember(IsRequired = true)]
        public string Email { get; set; }
    }
}
