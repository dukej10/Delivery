using PackageDelivery.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.GUI.Models.Core
{
    public class AddressModel
    {

        public long Id { get; set; }

        [Required]
        [DisplayName("Tipo de Calle")]
        public string TipoCalle { get; set; }

        [Required]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [Required]
        [DisplayName("Tipo de inmueble")]
        public string TipoInmueble { get; set; }

        [Required]
        [DisplayName("Nombre del barrio")]
        public string Barrio { get; set; }

        [Required]
        [DisplayName("Observaciones")]
        public string Observaciones { get; set; }

        [Required]
        [DisplayName("Actual")]
        public bool Actual { get; set; }

        //[Required]
        //[DisplayName("Id Municipio")]
        public long IdMunicipio { get; set; }

        //[Required]
        //[DisplayName("Id Persona")]
        public long IdPersona { get; set; }

        public string MunicipioName { get; set; }

        public string PersonaName { get; set; }

        public IEnumerable<MunicipalityModel> MunicipioList { get; set; }
        public IEnumerable<PersonModel> PersonaList { get; set; }
    }
}
