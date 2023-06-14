using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.Implementation.Core;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
    public class AddressImpApplication : IAddressApplication
    {
        IAddressRepository _repository = new AddressImpRepository();
        public AddressDTO createRecord(AddressDTO record)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDbModel dbModel = mapper.DTOToDbModelMapper(record);
            AddressDbModel response = this._repository.createRecord(dbModel);
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

        public AddressDTO getRecordById(int id)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<AddressDTO> getRecordList(string filter)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            IEnumerable<AddressDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public AddressDTO updateRecord(AddressDTO record)
        {
            AddressApplicationMapper mapper = new AddressApplicationMapper();
            AddressDbModel dbModel = mapper.DTOToDbModelMapper(record);
            AddressDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}
