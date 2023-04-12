using System;

namespace PackageDelivery.GUI.Models.Core
{
    public class PackageModel
    {
        public long Id { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }

        public double Width { get; set; }

        public Nullable<long> IdOffice { get; set; }
    }
}
