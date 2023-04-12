using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Contracts.DTO
{
    public class SendDTO
    {
        public long Id { get; set; }

        public DateTime SendDate { get; set; }

        public decimal Price { get; set; }

        public Nullable<long> IdSender { get; set; }

        public Nullable<long> idDestinationAddress { get; set; }

        public Nullable<long> IdPackage { get; set; }

        public Nullable<long> IdState { get; set; }

        public Nullable<long> IdTransportType { get; set; }
    }
}
