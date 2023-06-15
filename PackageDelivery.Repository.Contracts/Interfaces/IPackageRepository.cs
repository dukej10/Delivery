﻿using PackageDelivery.Repository.Contracts.DbModels.Core;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Contracts.Interfaces
{
    public interface IPackageRepository
    {
        PackageDbModel getRecordById(long id);

        IEnumerable<PackageDbModel> getRecordsList(string filter);

        PackageDbModel createRecord(PackageDbModel record);

        PackageDbModel updateRecord(PackageDbModel record);

        bool deleteRecordById(long id);
    }
}