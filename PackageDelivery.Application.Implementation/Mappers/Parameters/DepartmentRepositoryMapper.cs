using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    internal class DepartmentRepositoryMapper : DbModelMapperBase<DepartmentDbModel, departamento>
    {
        public override DepartmentDbModel DatabaseToDbModelMapper(departamento input)
        {
            return new DepartmentDbModel()
            {
                Id = input.id,
                Name = input.nombre,
            };
        }

        public override IEnumerable<DepartmentDbModel> DatabaseToDbModelMapper(IEnumerable<departamento> input)
        {
            IList<DepartmentDbModel> list = new List<DepartmentDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override departamento DbModelToDatabaseMapper(DepartmentDbModel input)
        {
            return new departamento()
            {
                id = input.Id,
                nombre = input.Name
            };
        }

        public override IEnumerable<departamento> DbModelToDatabaseMapper(IEnumerable<DepartmentDbModel> input)
        {
            IList<departamento> list = new List<departamento>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
