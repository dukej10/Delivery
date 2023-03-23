using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class TransportTypeRepositoryMapper : DbModelMapperBase<TransportTypeDbModel, tipoTransporte>

    {
        public override TransportTypeDbModel DatabaseToDbModelMapper(tipoTransporte input)
        {
            return new TransportTypeDbModel()
            {
                Id = input.id,
                Name = input.nombre,
            };
        }

        public override IEnumerable<TransportTypeDbModel> DatabaseToDbModelMapper(IEnumerable<tipoTransporte> input)
        {
            IList<TransportTypeDbModel> list = new List<TransportTypeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override tipoTransporte DbModelToDatabaseMapper(TransportTypeDbModel input)
        {
            return new tipoTransporte()
            {
                id = input.Id,
                nombre = input.Name
            };
        }

        public override IEnumerable<tipoTransporte> DbModelToDatabaseMapper(IEnumerable<TransportTypeDbModel> input)
        {
            IList<tipoTransporte> list = new List<tipoTransporte>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
