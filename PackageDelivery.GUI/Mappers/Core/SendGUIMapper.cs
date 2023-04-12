using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    public class SendGUIMapper : ModelMapperBase<SendModel, SendDTO>
    {
        public override SendModel DTOToModelMapper(SendDTO input)
        {
            return new SendModel()
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

        public override IEnumerable<SendModel> DTOToModelMapper(IEnumerable<SendDTO> input)
        {
            IList<SendModel> list = new List<SendModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override SendDTO ModelToDTOMapper(SendModel input)
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

        public override IEnumerable<SendDTO> ModelToDTOMapper(IEnumerable<SendModel> input)
        {
                 IList<SendDTO> list = new List<SendDTO>();
                foreach (var item in input)
                {
                    list.Add(this.ModelToDTOMapper(item));
                }
                return list;
        }
    }
}
