using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.Implementation.Parameters;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class TransportTypeImpApplication: ITransportTypeApplication
    {
        ITransportTypeRepository _repository = new TransportTypeImpRepository();
        public TransportTypeDTO createRecord(TransportTypeDTO record)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDbModel dbModel = mapper.DTOToDbModelMapper(record);
            TransportTypeDbModel response = this._repository.createRecord(dbModel);
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

        public TransportTypeDTO getRecordById(int id)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<TransportTypeDTO> getRecordsList(string filter)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            IEnumerable<TransportTypeDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public TransportTypeDTO updateRecord(TransportTypeDTO record)
        {
            TransportTypeApplicationMapper mapper = new TransportTypeApplicationMapper();
            TransportTypeDbModel dbModel = mapper.DTOToDbModelMapper(record);
            TransportTypeDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}
