using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class PackageRepositoryMapper : DbModelMapperBase<PackageDbModel, paquete>
    {
        public override PackageDbModel DatabaseToDbModelMapper(paquete input)
        {
            return new PackageDbModel()
            {
                Id = input.id,
                Weight = input.peso,
                Height = input.altura,
                Depth = input.profundidad,
                Width = input.ancho,
                Code = input.codigo,
                IdOffice = input.idOficina
            };
        }

        public override IEnumerable<PackageDbModel> DatabaseToDbModelMapper(IEnumerable<paquete> input)
        {
            IList<PackageDbModel> list = new List<PackageDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override paquete DbModelToDatabaseMapper(PackageDbModel input)
        {
            return new paquete()
            {
                id = input.Id,
                peso = input.Weight,
                altura = input.Height,
                profundidad = input.Depth,
                ancho = input.Width,
                codigo = input.Code,
                idOficina = input.IdOffice

            };
        }

        public override IEnumerable<paquete> DbModelToDatabaseMapper(IEnumerable<PackageDbModel> input)
        {
            IList<paquete> list = new List<paquete>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
