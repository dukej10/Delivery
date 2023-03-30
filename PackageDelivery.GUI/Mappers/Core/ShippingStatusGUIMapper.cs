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
    internal class ShippingStatusGUIMapper : ModelMapperBase<ShippingStatusModel, ShippingStatusDTO>
    {
        public override ShippingStatusModel DTOToModelMapper(ShippingStatusDTO input)
        {
            return new ShippingStatusModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<ShippingStatusModel> DTOToModelMapper(IEnumerable<ShippingStatusDTO> input)
        {
            IList<ShippingStatusModel> list = new List<ShippingStatusModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override ShippingStatusDTO ModelToDTOMapper(ShippingStatusModel input)
        {
            return new ShippingStatusDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<ShippingStatusDTO> ModelToDTOMapper(IEnumerable<ShippingStatusModel> input)
        {
            IList<ShippingStatusDTO> list = new List<ShippingStatusDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }   
    

    
}
