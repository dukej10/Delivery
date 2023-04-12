using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Mappers.Parameters
{
    public class MunicipalityGUIMapper : ModelMapperBase<MunicipalityModel, MunicipalityDTO>

    {
        public override MunicipalityModel DTOToModelMapper(MunicipalityDTO input)
        {
            return new MunicipalityModel()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<MunicipalityModel> DTOToModelMapper(IEnumerable<MunicipalityDTO> input)
        {
            IList<MunicipalityModel> list = new List<MunicipalityModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override MunicipalityDTO ModelToDTOMapper(MunicipalityModel input)
        {
            return new MunicipalityDTO()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<MunicipalityDTO> ModelToDTOMapper(IEnumerable<MunicipalityModel> input)
        {
            IList<MunicipalityDTO> list = new List<MunicipalityDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
    }