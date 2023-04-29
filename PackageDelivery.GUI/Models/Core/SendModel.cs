using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PackageDelivery.GUI.Models.Core
{
    public class SendModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Fecha de envio")]
        public DateTime SendDate { get; set; }

        [Required]
        [DisplayName("Precio de envio")]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Id Remitente")]
        public Nullable<long> IdSender { get; set; }

        [Required]
        [DisplayName("Id dirección de destino")]
        public Nullable<long> idDestinationAddress { get; set; }

        [Required]
        [DisplayName("Id del paquete")]
        public Nullable<long> IdPackage { get; set; }

        [Required]
        [DisplayName("Id del estado")]
        public Nullable<long> IdState { get; set; }

        [Required]
        [DisplayName("Id del tipo de transporte")]
        public Nullable<long> IdTransportType { get; set; }
    }
}