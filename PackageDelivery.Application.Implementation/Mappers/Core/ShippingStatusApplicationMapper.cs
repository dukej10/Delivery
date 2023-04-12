using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Implementation.Mappers;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    internal class ShippingStatusApplicationMapper : DTOMapperBase<ShippingStatusDTO, ShippingStatusDbModel>
    {
        public override ShippingStatusDTO DbModelToDTOMapper(ShippingStatusDbModel input)
        {
            return new ShippingStatusDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<ShippingStatusDTO> DbModelToDTOMapper(IEnumerable<ShippingStatusDbModel> input)
        {
            IList<ShippingStatusDTO> list = new List<ShippingStatusDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override ShippingStatusDbModel DTOToDbModelMapper(ShippingStatusDTO input)
        {
            return new ShippingStatusDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<ShippingStatusDbModel> DTOToDbModelMapper(IEnumerable<ShippingStatusDTO> input)
        {
            IList<ShippingStatusDbModel> list = new List<ShippingStatusDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }   
    

    
}
