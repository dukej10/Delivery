using PackageDelivery.Application.Implementation.Mappers;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Parameters
{
    public class TransportGUIMapper : ModelMapperBase<TransportTypeDTO, TransportTypeDbModel>

    {
        public override TransportTypeDTO DTOToModelMapper(TransportTypeDbModel input)
        {
            return new TransportTypeDTO()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<TransportTypeDTO> DTOToModelMapper(IEnumerable<TransportTypeDbModel> input)
        {
            IList<TransportTypeDTO> list = new List<TransportTypeDTO>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override TransportTypeDbModel ModelToDTOMapper(TransportTypeDTO input)
        {
            return new TransportTypeDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<TransportTypeDbModel> ModelToDTOMapper(IEnumerable<TransportTypeDTO> input)
        {
            IList<TransportTypeDbModel> list = new List<TransportTypeDbModel>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
