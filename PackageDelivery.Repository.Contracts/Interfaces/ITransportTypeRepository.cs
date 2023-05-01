using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Contracts.Interfaces
{
    public interface ITransportTypeRepository
    {
        TransportTypeDbModel getRecordById(int id);
        IEnumerable<TransportTypeDbModel> getRecordsList(string filter);

        TransportTypeDbModel createRecord(TransportTypeDbModel record);

        TransportTypeDbModel updateRecord(TransportTypeDbModel record);

        bool deleteRecordById(int id);
    }
}
