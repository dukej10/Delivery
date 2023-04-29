using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Mappers.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Implementation.Implementation.Parameters
{
    public class MunicipalityImpApplication: IMunicipalityApplication
    {
        IMunicipalityRepository _repository = new MunicipalityImpRepository();
        public MunicipalityDTO createRecord(MunicipalityDTO record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public MunicipalityDTO getRecordById(int id)
        {
            MunicipalityApplicationMapper mapper = new MunicipalityApplicationMapper();
            MunicipalityDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<MunicipalityDTO> getRecordsList(string filter)
        {
            MunicipalityApplicationMapper mapper = new MunicipalityApplicationMapper();
            IEnumerable<MunicipalityDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public MunicipalityDTO updateRecord(MunicipalityDTO record)
        {
            throw new NotImplementedException();
        }
    }
}
