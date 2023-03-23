using System;

namespace PackageDelivery.Repository.Contracts.DbModels.Core
{
    public class SendDbModel
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
