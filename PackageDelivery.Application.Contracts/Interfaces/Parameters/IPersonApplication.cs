using PackageDelivery.Application.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IPersonApplication
    {
        PersonDTO getRecordById(int id);
        IEnumerable<PersonDTO> getRecordsList(string filter);

        PersonDTO createRecord(PersonDTO record);

        PersonDTO updateRecord(PersonDTO record);

        bool deleteRecordById(int id);
    }
}
