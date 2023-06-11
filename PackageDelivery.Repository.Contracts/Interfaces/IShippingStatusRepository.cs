using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces
{
    public interface IShippingStatusRepository
    {
        ShippingStatusDbModel getRecordById(int id);
        IEnumerable<ShippingStatusDbModel> getRecordsList(string filter);
        ShippingStatusDbModel createRecord(ShippingStatusDbModel record);
        ShippingStatusDbModel updateRecord(ShippingStatusDbModel record);
        bool deleteRecordById(int id);
    }
}
