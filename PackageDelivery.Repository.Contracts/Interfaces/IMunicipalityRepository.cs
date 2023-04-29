using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces
{
    public interface IMunicipalityRepository
    {
        MunicipalityDbModel getRecordById(int id);
        IEnumerable<MunicipalityDbModel> getRecordsList(string filter);
        MunicipalityDbModel createRecord(MunicipalityDbModel record);
        MunicipalityDbModel updateRecord(MunicipalityDbModel record);
        bool deleteRecordById(int id);
    }
}
