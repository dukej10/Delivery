using PackageDelivery.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Contracts.Interfaces.Core
{
    public interface IShippingStatusApplication
    {
        ShippingStatusDTO getRecordById(int id);
        IEnumerable<ShippingStatusDTO> getRecordsList(string filter);

        ShippingStatusDTO createRecord(ShippingStatusDTO record);

        ShippingStatusDTO updateRecord(ShippingStatusDTO record);

        bool deleteRecordById(int id);

    }
}
