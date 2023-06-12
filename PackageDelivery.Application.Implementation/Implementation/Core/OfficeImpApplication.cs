﻿using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Mappers.Core;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.Implementation.Core;
using System.Collections.Generic;

namespace PackageDelivery.Application.Implementation.Implementation.Core
{
    public class OfficeImpApplication : IOfficeApplication
    {
        IOfficeRepository _repository = new OfficeImpRepository();

        public OfficeDTO createRecord(OfficeDTO record)
        {
            OfficeApplicationMapper mapper = new OfficeApplicationMapper();
            OfficeDbModel dbModel = mapper.DTOToDbModelMapper(record);
            OfficeDbModel response = this._repository.createRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }

        public bool deleteRecordById(long id)
        {
            return _repository.deleteRecordById(id);
        }

        public OfficeDTO getRecordById(long id)
        {
            OfficeApplicationMapper mapper = new OfficeApplicationMapper();
            OfficeDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<OfficeDTO> getRecordsList(string filter)
        {
            OfficeApplicationMapper mapper = new OfficeApplicationMapper();
            IEnumerable<OfficeDbModel> dbModelList = _repository.getRecordsList(filter);
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public OfficeDTO updateRecord(OfficeDTO record)
        {
            OfficeApplicationMapper mapper = new OfficeApplicationMapper();
            OfficeDbModel dbModel = mapper.DTOToDbModelMapper(record);
            OfficeDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}
