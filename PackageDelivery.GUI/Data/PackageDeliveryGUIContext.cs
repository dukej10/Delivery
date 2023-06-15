using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PackageDelivery.GUI.Data
{
    public class PackageDeliveryGUIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public PackageDeliveryGUIContext() : base("name=PackageDeliveryGUIContext")
        {
        }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.PersonModel> PersonModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.OfficeModel> OfficeModels { get; set; }

        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Core.PackageModel> PackageModels { get; set; }
        public System.Data.Entity.DbSet<PackageDelivery.GUI.Models.Parameters.MunicipalityModel> MunicipalityModels { get; set; }
    }
}
