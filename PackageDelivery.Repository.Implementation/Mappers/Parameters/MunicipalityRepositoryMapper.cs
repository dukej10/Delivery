using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class MunicipalityRepositoryMapper : DbModelMapperBase<MunicipalityDbModel, municipio>
    {
        public override MunicipalityDbModel DatabaseToDbModelMapper(municipio input)
        {
            return new MunicipalityDbModel()
            {
                Id = input.id,
                Name = input.nombre,
            };
        }

        public override IEnumerable<MunicipalityDbModel> DatabaseToDbModelMapper(IEnumerable<municipio> input)
        {
            IList<MunicipalityDbModel> list = new List<MunicipalityDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override municipio DbModelToDatabaseMapper(MunicipalityDbModel input)
        {
            return new municipio()
            {
                id = input.Id,
                nombre = input.Name
            };
        }

        public override IEnumerable<municipio> DbModelToDatabaseMapper(IEnumerable<MunicipalityDbModel> input)
        {
            IList<municipio> list = new List<municipio>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
