using PackageDelivery.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface ITransportTypeApplication
    {
        TransportTypeDTO getRecordById(int id);
        IEnumerable<TransportTypeDTO> getRecordsList(string filter);

        TransportTypeDTO createRecord(TransportTypeDTO record);

        TransportTypeDTO updateRecord(TransportTypeDTO record);

        bool deleteRecordById(int id);
    }
}
