using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Implementation.Mappers.Parameters
{
    public class TransportGUIMapper : ModelMapperBase<TransportTypeModel, TransportTypeDbModel>

    {
        public override TransportTypeModel DTOToModelMapper(TransportTypeDbModel input)
        {
            return new TransportTypeModel()
            {
                Id = input.Id,
                Name = input.Name,
            };
        }

        public override IEnumerable<TransportTypeModel> DTOToModelMapper(IEnumerable<TransportTypeDbModel> input)
        {
            IList<TransportTypeModel> list = new List<TransportTypeModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override TransportTypeDbModel ModelToDTOMapper(TransportTypeModel input)
        {
            return new TransportTypeDbModel()
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public override IEnumerable<TransportTypeDbModel> ModelToDTOMapper(IEnumerable<TransportTypeModel> input)
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
