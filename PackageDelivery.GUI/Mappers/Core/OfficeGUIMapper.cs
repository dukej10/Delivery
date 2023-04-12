using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Core
{
    public class OfficeGUIMapper : ModelMapperBase<OfficeModel, OfficeDTO>
    {
        public override OfficeModel DTOToModelMapper(OfficeDTO input)
        {
            return new OfficeModel()
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

        public override IEnumerable<OfficeModel> DTOToModelMapper(IEnumerable<OfficeDTO> input)
        {
            IList<OfficeModel> list = new List<OfficeModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override OfficeDTO ModelToDTOMapper(OfficeModel input)
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

        public override IEnumerable<OfficeDTO> ModelToDTOMapper(IEnumerable<OfficeModel> input)
        {
            IList<OfficeDTO> list = new List<OfficeDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
