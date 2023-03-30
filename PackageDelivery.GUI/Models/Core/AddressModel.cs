using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.GUI.Models.Core
{
    public class AddressModel
    {

        public long Id { get; set; }    
        public string TipoCalle { get; set; }
        public string Numero { get; set; }
        public string TipoInmueble { get; set; }
        public string Barrio { get; set; }
        public string Observaciones { get; set; }
        public bool Actual { get; set; }
        public long IdMunicipio { get; set; }
        public long IdPersona { get; set; }
    }
}
