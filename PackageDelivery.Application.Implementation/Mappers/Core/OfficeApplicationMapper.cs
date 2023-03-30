using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Mappers.Core
{
    public class OfficeApplicationMapper : DTOMapperBase<OfficeDTO, OfficeDbModel>
    {
        public override OfficeDTO DbModelToDTOMapper(OfficeDbModel input)
        {
            return new OfficeDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Phone = input.Phone,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                Address = input.Address,
                IdMunicipality = input.IdMunicipality
            };
        }

        public override IEnumerable<OfficeDTO> DbModelToDTOMapper(IEnumerable<OfficeDbModel> input)
        {
            IList<OfficeDTO> list = new List<OfficeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override OfficeDbModel DTOToDbModelMapper(OfficeDTO input)
        {
            return new OfficeDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Code = input.Code,
                Phone = input.Phone,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                Address = input.Address,
                IdMunicipality = input.IdMunicipality
            };
        }

        public override IEnumerable<OfficeDbModel> DTOToDbModelMapper(IEnumerable<OfficeDTO> input)
        {
            IList<OfficeDbModel> list = new List<OfficeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
