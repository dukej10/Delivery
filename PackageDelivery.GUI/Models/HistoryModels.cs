//HistoryModels

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace PackageDelivery.GUI.Models
{
    public class IndexViewModel
    {

        public dateTime admissionDate { get; set; } //
        public dateTime departureDate { get; set; }//
        public string descripcion { get; set; }//

    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }



    public class VerifyadmissionDateViewModel
    {
        
        [Required]
        [admissionDate]
        [Display(Name = "Fecha de Ingreso")]
        public dateTime admissionDate { get; set; }

        [Required]
        [Display(Name = "fecha de salida")]
        public dateTime departureDate { get; set; }

        [Required]
        [Display(Name = "fecha de salida")]
        public string descripcion { get; set; }

    }

    public class ConfiguredescripcionViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}