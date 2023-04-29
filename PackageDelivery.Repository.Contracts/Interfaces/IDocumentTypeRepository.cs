using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Contracts.Interfaces
{
    public interface IDocumentTypeRepository
    {
        DocumentTypeDbModel getRecordById(int id);
        IEnumerable<DocumentTypeDbModel> getRecordsList(string filter);
        DocumentTypeDbModel createRecord(DocumentTypeDbModel record);
        DocumentTypeDbModel updateRecord(DocumentTypeDbModel record);
        bool deleteRecordById(int id);
    }
}
