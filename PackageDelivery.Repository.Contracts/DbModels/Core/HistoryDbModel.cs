using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Contracts.DbModels.Core
{
    public class HistoryDbModel
    {
        public long Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Description { get; set; }
        public Nullable<long> IdPackage { get; set; }
        public Nullable<long> IdStore { get; set; }
    }
}
