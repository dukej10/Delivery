using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class OfficeModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Código")]
        public string Code { get; set; }

        [Required]
        [DisplayName("N° Contacto")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Latitud")]
        public string Latitude { get; set; }

        [Required]
        [DisplayName("Longitud")]
        public string Longitude { get; set; }

        [Required]
        [DisplayName("Dirección")]
        public string Address { get; set; }
        
        [Required]
        [DisplayName("Municipio")]
        public long IdMunicipality { get; set; }

        public IEnumerable<MunicipalityModel> MunicipalityList { get; set; }
    }
}
