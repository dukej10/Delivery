using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class StoreGUIMapper : ModelMapperBase<StoreModel, StoreDTO>
    {
        public override StoreModel DTOToModelMapper(StoreDTO input)
        {
            return new StoreModel()
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Address = input.Address,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                IdMunicipality = input.IdMunicipality
            };
        }

        public override IEnumerable<StoreModel> DTOToModelMapper(IEnumerable<StoreDTO> input)
        {
            IList<StoreModel> list = new List<StoreModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override StoreDTO ModelToDTOMapper(StoreModel input)
        {
              return new StoreDTO()
            {
                  Id = input.Id,
                  Name = input.Name,
                  Code = input.Code,
                  Address = input.Address,
                  Latitude = input.Latitude,
                  Longitude = input.Longitude,
                  IdMunicipality = input.IdMunicipality

              };
        }

        public override IEnumerable<StoreDTO> ModelToDTOMapper(IEnumerable<StoreModel> input)
        {
            IList<StoreDTO> list = new List<StoreDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
