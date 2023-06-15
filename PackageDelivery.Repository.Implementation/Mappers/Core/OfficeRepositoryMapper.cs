using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class OfficeRepositoryMapper : DbModelMapperBase<OfficeDbModel, oficina>
    {
        public override OfficeDbModel DatabaseToDbModelMapper(oficina input)
        {
            return new OfficeDbModel()
            {
                Id = input.id,
                Name = input.nombre,
                Code = input.codigo,
                Phone = input.telefono,
                Latitude = input.latitud,
                Longitude = input.longitud,
                Address = input.direccion,
                IdMunicipality = (long)input.idMunicipio
            };
        }

        public override IEnumerable<OfficeDbModel> DatabaseToDbModelMapper(IEnumerable<oficina> input)
        {
            IList<OfficeDbModel> list = new List<OfficeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override oficina DbModelToDatabaseMapper(OfficeDbModel input)
        {
            return new oficina()
            {
                id = input.Id,
                nombre = input.Name,
                codigo = input.Code,
                telefono = input.Phone,
                latitud = input.Latitude,
                longitud = input.Longitude,
                direccion = input.Address,
                idMunicipio = input.IdMunicipality
            };
        }

        public override IEnumerable<oficina> DbModelToDatabaseMapper(IEnumerable<OfficeDbModel> input)
        {
            IList<oficina> list = new List<oficina>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
