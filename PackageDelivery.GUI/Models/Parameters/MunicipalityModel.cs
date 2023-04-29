using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class MunicipalityModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Nombre Municipio")]
        public string Name { get; set; }
    }
}