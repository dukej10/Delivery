using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PersonModel
    {

        public long Id { get; set; }

        [Required]
        [DisplayName("Primer Nombre")]
        public string FirstName { get; set; }

        [DisplayName("Otros Nombres")]
        public string OtherNames { get; set; }

        [Required]
        [DisplayName("Primer Apellido")]
        public string FirstLastname { get; set; }

        [DisplayName("Segundo Apellido")]
        public string SecondLastname { get; set; }

        [Required]
        [DisplayName("Identificación")]
        public string IdentificationNumber { get; set; }

        [Required]
        [DisplayName("Celular")]
        public string Cellphone { get; set; }

        [Required]
        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Tipo de Documento")]
        public int IdentificationType { get; set; }

        public string DocumentTypeName { get; set; }

        public IEnumerable<DocumentTypeModel> DocumentTypeList { get; set; }

        

    }
}