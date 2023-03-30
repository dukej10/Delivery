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

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    internal class VehicleRepositoryMapper : DbModelMapperBase<VehicleDbModel, vehiculo>
    {
        public override VehicleDbModel DatabaseToDbModelMapper(vehiculo input)
        {
            return new VehicleDbModel()
            {
                Id = input.id, 
                plate = input.placa,
                IdTransportType = input.idTipoTransporte
            };
        }

        public override IEnumerable<VehicleDbModel> DatabaseToDbModelMapper(IEnumerable<vehiculo> input)
        {
            IList<VehicleDbModel> list = new List<VehicleDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override vehiculo DbModelToDatabaseMapper(VehicleDbModel input)
        {
            return new vehiculo()
            {
                id = input.Id, 
                placa = input.plate, 
                idTipoTransporte = input.IdTransportType
            };
        }

        public override IEnumerable<vehiculo> DbModelToDatabaseMapper(IEnumerable<VehicleDbModel> input)
        {
            IList<vehiculo> list = new List<vehiculo>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
