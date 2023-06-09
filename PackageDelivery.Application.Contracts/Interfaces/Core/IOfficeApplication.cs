using PackageDelivery.Application.Contracts.DTO;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IOfficeApplication
    {
        OfficeDTO getRecordById(long? id);
        IEnumerable<OfficeDTO> getRecordsList(string filter);

        OfficeDTO createRecord(OfficeDTO record);

        OfficeDTO updateRecord(OfficeDTO record);

        bool deleteRecordById(int id);
    }
}
