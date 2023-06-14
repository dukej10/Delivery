using PackageDelivery.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IAddressApplication
    {
        AddressDTO getRecordById(int id);
        IEnumerable<AddressDTO> getRecordList(string filter);
        AddressDTO createRecord(AddressDTO record);
        AddressDTO updateRecord(AddressDTO record);
        bool deleteRecordById(int id);
    }
}
