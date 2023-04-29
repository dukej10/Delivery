using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Contracts.Interfaces
{
    public interface IDepartmentRepository
    {
        DepartmentDbModel getRecordById(int id);
        IEnumerable<DepartmentDbModel> getRecordsList(string filter);

        DepartmentDbModel createRecord(DepartmentDbModel record);

        DepartmentDbModel updateRecord(DepartmentDbModel record);

        bool deleteRecordById(int id);
    }
}
