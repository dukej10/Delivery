using PackageDelivery.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IMunicipalityApplication
    {
        MunicipalityDTO getRecordById(int id);
        IEnumerable<MunicipalityDTO> getRecordsList(string filter);

        MunicipalityDTO createRecord(MunicipalityDTO record);

        MunicipalityDTO updateRecord(MunicipalityDTO record);

        bool deleteRecordById(int id);
    }
}
