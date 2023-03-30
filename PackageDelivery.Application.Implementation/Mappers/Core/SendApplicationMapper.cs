using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Implementation.Mappers;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class SendApplicationMapper : DTOMapperBase<SendDTO, SendDbModel>
    {
        public override SendDTO DbModelToDTOMapper(SendDbModel input)
        {
            return new SendDTO()
            {
                Id = input.Id,
                SendDate = input.SendDate,
                Price = input.Price,
                IdSender = input.IdSender,
                idDestinationAddress = input.idDestinationAddress,
                IdPackage = input.IdPackage,
                IdState = input.IdState,
                IdTransportType = input.IdTransportType
            };
        }

        public override IEnumerable<SendDTO> DbModelToDTOMapper(IEnumerable<SendDbModel> input)
        {
            IList<SendDTO> list = new List<SendDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override SendDbModel DTOToDbModelMapper(SendDTO input)
        {
            return new SendDbModel()
            {
                Id = input.Id,
                SendDate = input.SendDate,
                Price = input.Price,
                IdSender = input.IdSender,
                idDestinationAddress = input.idDestinationAddress,
                IdPackage = input.IdPackage,
                IdState = input.IdState,
                IdTransportType = input.IdTransportType
                
            };
        }

        public override IEnumerable<SendDbModel> DTOToDbModelMapper(IEnumerable<SendDTO> input)
        {
                 IList<SendDbModel> list = new List<SendDbModel>();
                foreach (var item in input)
                {
                    list.Add(this.DTOToDbModelMapper(item));
                }
                return list;
        }
    }
}
