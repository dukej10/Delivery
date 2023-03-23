using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Contracts.DbModels.Core
{
    public class OfficeDbModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Phone { get; set; }
        
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Address { get; set; }

        public Nullable<long> IdMunicipal { get; set; }


    }
}
