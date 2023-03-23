using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class SendRepositoryMapper : DbModelMapperBase<SendDbModel, envio>
    {
        public override SendDbModel DatabaseToDbModelMapper(envio input)
        {
            return new SendDbModel()
            {
                Id = input.id,
                SendDate = input.fechaEnvio,
                Price = input.precio,
                IdSender = input.idRemitente,
                idDestinationAddress = input.idDireccionDestino,
                IdPackage = input.idPaquete,
                IdState = input.idEstado,
                IdTransportType = input.idTipoTransporte
            };
        }

        public override IEnumerable<SendDbModel> DatabaseToDbModelMapper(IEnumerable<envio> input)
        {
            IList<SendDbModel> list = new List<SendDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override envio DbModelToDatabaseMapper(SendDbModel input)
        {
            return new envio()
            {
                id = input.Id,
                fechaEnvio = input.SendDate,
                precio = input.Price,
                idRemitente = input.IdSender,
                idDireccionDestino = input.idDestinationAddress,
                idPaquete = input.IdPackage,
                idEstado = input.IdState,
                idTipoTransporte = input.IdTransportType
                
            };
        }

        public override IEnumerable<envio> DbModelToDatabaseMapper(IEnumerable<SendDbModel> input)
        {
                 IList<envio> list = new List<envio>();
                foreach (var item in input)
                {
                    list.Add(this.DbModelToDatabaseMapper(item));
                }
                return list;
        }
    }
}
