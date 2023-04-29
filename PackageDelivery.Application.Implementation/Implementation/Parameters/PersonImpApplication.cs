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

    public class PersonImpApplication : IPersonApplication
    {
        IPersonRepository _repository = new PersonImpRepository();
        public PersonDTO createRecord(PersonDTO record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public PersonDTO getRecordById(int id)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            PersonDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<PersonDTO> getRecordsList(string filter)
        {
            PersonApplicationMapper mapper = new PersonApplicationMapper();
            IEnumerable<PersonDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public PersonDTO updateRecord(PersonDTO record)
        {
            throw new NotImplementedException();
        }
    }
}
