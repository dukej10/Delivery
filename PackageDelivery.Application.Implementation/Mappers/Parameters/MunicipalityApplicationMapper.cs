using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Implementation.Mappers;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Mappers.Parameters
{
    public class MunicipalityApplicationMapper : DTOMapperBase<MunicipalityDTO, MunicipalityDbModel>
    {
        public override MunicipalityDTO DbModelToDTOMapper(MunicipalityDbModel input)
        {
            return new MunicipalityDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<MunicipalityDTO> DbModelToDTOMapper(IEnumerable<MunicipalityDbModel> input)
        {
            IList<MunicipalityDTO> list = new List<MunicipalityDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override MunicipalityDbModel DTOToDbModelMapper(MunicipalityDTO input)
        {
            return new MunicipalityDbModel()
            {
                Id = input.Id,
                Name = input.Name,

            };
        }

        public override IEnumerable<MunicipalityDbModel> DTOToDbModelMapper(IEnumerable<MunicipalityDTO> input)
        {
            IList<MunicipalityDbModel> list = new List<MunicipalityDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
