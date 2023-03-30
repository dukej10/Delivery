using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class StoreRepositoryMapper : DbModelMapperBase<StoreDbModel, bodega>
    {
        public override StoreDbModel DatabaseToDbModelMapper(bodega input)
        {
            return new StoreDbModel()
            {
                Id = input.id,
                Name = input.nombre,
                Code = input.codigo,
                Address = input.direccion,
                Latitude = input.latitud,
                Longitude = input.longitud,
                IdMunicipality = input.idMunicipio
            };
        }

        public override IEnumerable<StoreDbModel> DatabaseToDbModelMapper(IEnumerable<bodega> input)
        {
            IList<StoreDbModel> list = new List<StoreDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override bodega DbModelToDatabaseMapper(StoreDbModel input)
        {
              return new bodega()
            {
                id = input.Id,
                nombre = input.Name,
                codigo = input.Code,
                direccion = input.Address,
                latitud = input.Latitude,
                longitud = input.Longitude,
                idMunicipio = input.IdMunicipality
                
            };
        }

        public override IEnumerable<bodega> DbModelToDatabaseMapper(IEnumerable<StoreDbModel> input)
        {
            IList<bodega> list = new List<bodega>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
