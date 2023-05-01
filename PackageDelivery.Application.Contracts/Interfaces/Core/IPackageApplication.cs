﻿using PackageDelivery.Application.Contracts.DTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IPackageApplication
    {
        PackageDTO getRecordById(int id);
        IEnumerable<PackageDTO> getRecordsList(string filter);

        PackageDTO createRecord(PackageDTO record);

        PackageDTO updateRecord(PackageDTO record);

        bool deleteRecordById(int id);
    }
}
