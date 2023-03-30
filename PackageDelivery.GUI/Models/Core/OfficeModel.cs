using System;

namespace PackageDelivery.GUI.Models.Core
{
    public class OfficeModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Phone { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Address { get; set; }

        public Nullable<long> IdMunicipality { get; set; }
    }
}
