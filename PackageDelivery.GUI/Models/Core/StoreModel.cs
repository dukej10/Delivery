using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class StoreModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Código")]
        public string Code { get; set; }

        [Required]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Latitud")]
        public string Latitude { get; set; }

        [Required]
        [DisplayName("Longitud")]
        public string Longitude { get; set; }

        [Required]
        [DisplayName("Id del Municipio")]
        public long IdMunicipality { get; set; }
    }
}
