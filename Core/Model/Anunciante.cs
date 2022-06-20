using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Anunciante
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string NumeroFiscal { get; set; }

        public string ReferenciaImagemPerfil { get; set; }

        public List<TagAnunciante> Tags { get; set; }

        public EmailAnunciante Email { get; set; }
    }
}
