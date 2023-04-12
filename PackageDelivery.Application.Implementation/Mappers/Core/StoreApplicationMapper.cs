using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    public class StoreApplicationMapper : DTOMapperBase<StoreDTO, StoreDbModel>
    {
        public override StoreDTO DbModelToDTOMapper(StoreDbModel input)
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

        public override IEnumerable<StoreDTO> DbModelToDTOMapper(IEnumerable<StoreDbModel> input)
        {
            IList<StoreDTO> list = new List<StoreDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override StoreDbModel DTOToDbModelMapper(StoreDTO input)
        {
              return new StoreDbModel()
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

        public override IEnumerable<StoreDbModel> DTOToDbModelMapper(IEnumerable<StoreDTO> input)
        {
            IList<StoreDbModel> list = new List<StoreDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
