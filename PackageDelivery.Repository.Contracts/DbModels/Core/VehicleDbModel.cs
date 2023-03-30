
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Contracts.DbModels.Parameters
{
    public class VehicleDbModel
    {
        public long Id { get; set; }
        public string plate { get; set; }
        public Nullable<long> IdTransportType { get; set; }
    }
}