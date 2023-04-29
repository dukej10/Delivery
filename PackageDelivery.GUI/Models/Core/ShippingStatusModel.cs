using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.GUI.Models.Core
{
    public class ShippingStatusModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Nombre del estado")]
        public string Name { get; set; }

    }
}
