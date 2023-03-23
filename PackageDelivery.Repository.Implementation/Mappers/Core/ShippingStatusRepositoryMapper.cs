using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    internal class ShippingStatusRepositoryMapper : DbModelMapperBase<ShippingStatusDbModel, estadoEnvio>
    {
        public override ShippingStatusDbModel DatabaseToDbModelMapper(estadoEnvio input)
        {
            return new ShippingStatusDbModel()
            {
                Id = input.id,
                Name = input.nombre
            };
        }

        public override IEnumerable<ShippingStatusDbModel> DatabaseToDbModelMapper(IEnumerable<estadoEnvio> input)
        {
            IList<ShippingStatusDbModel> list = new List<ShippingStatusDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override estadoEnvio DbModelToDatabaseMapper(ShippingStatusDbModel input)
        {
            return new estadoEnvio()
            {
                id = input.Id,
                nombre = input.Name
            };
        }

        public override IEnumerable<estadoEnvio> DbModelToDatabaseMapper(IEnumerable<ShippingStatusDbModel> input)
        {
            IList<estadoEnvio> list = new List<estadoEnvio>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }   
    

    
}
