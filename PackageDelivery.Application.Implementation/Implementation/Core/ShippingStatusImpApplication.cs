using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.Implementation.Core;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
    public class ShippingStatusImpApplication : IShippingStatusApplication
    {
        IShippingStatusRepository _repository = new ShippingStatusImpRepository();
        public ShippingStatusDTO createRecord(ShippingStatusDTO record)
        {
            ShippingStatusApplicationMapper mapper = new ShippingStatusApplicationMapper();
            ShippingStatusDbModel dbModel = mapper.DTOToDbModelMapper(record);
            ShippingStatusDbModel response = this._repository.createRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public ShippingStatusDTO getRecordById(int id)
        {
            ShippingStatusApplicationMapper mapper = new ShippingStatusApplicationMapper();
            ShippingStatusDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<ShippingStatusDTO> getRecordsList(string filter)
        {
            ShippingStatusApplicationMapper mapper = new ShippingStatusApplicationMapper();
            IEnumerable<ShippingStatusDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public ShippingStatusDTO updateRecord(ShippingStatusDTO record)
        {
            ShippingStatusApplicationMapper mapper = new ShippingStatusApplicationMapper();
            ShippingStatusDbModel dbModel = mapper.DTOToDbModelMapper(record);
            ShippingStatusDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}
