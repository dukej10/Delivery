using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class DocumentTypeModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Tipo de de Documento")]
        public string Name { get; set; }
    }
}