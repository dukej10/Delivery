//HistoryRepositoryMapper
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    internal class HistoryRepositoryMapper : DbModelMapperBase<HistoryDbModel, historial>
    {
        public override HistoryDbModel DatabaseToDbModelMapper(historial input)
        {
            return new HistoryDbModel()
            {
                Id = input.id,
                AdmissionDate = input.fechaIngreso,
                DepartureDate = input.fechaSalida,
                Description = input.descripcion,
                IdPackage = input.idPaquete,
                IdStore = input.idBodega
            };
        }

        public override IEnumerable<HistoryDbModel> DatabaseToDbModelMapper(IEnumerable<historial> input)
        {
            IList<HistoryDbModel> list = new List<HistoryDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override historial DbModelToDatabaseMapper(HistoryDbModel input)
        {
            return new historial()
            {
                id = input.Id,
                fechaIngreso = input.AdmissionDate,
                fechaSalida = input.DepartureDate,
                descripcion = input.Description,
                idPaquete = input.IdPackage,
                idBodega = input.IdStore
            };
        }

        public override IEnumerable<historial> DbModelToDatabaseMapper(IEnumerable<HistoryDbModel> input)
        {
            IList<historial> list = new List<historial>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
