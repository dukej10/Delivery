using System;

namespace PackageDelivery.Repository.Contracts.DbModels.Core
{
    public class HistoryDbModel
    {
        public long Id { get; set; }

        public DateTime SendDate { get; set; }

        public decimal Price { get; set; }

        public long IdSender { get; set; }

        public long idAddress { get; set; }

        public long IdPackage { get; set; }

        public long idState { get; set; }

        public long IdTransportType { get; set; }
    }
}
