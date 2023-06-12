using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Core
{
    public class PackageModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Peso")]
        public double Weight { get; set; }

        [Required]
        [DisplayName("Altura")]
        public double Height { get; set; }

        [Required]
        [DisplayName("Profundidad")]
        public double Depth { get; set; }

        [Required]
        [DisplayName("Anchura")]
        public double Width { get; set; }

        [Required]
        [DisplayName("Oficina")]
        public long IdOffice { get; set; }

        public IEnumerable<OfficeModel> OfficeList { get; set; }
    }
}
