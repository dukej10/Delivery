using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IDepartmentApplication
    {
        DepartmentDTO getRecordById(int id);
        IEnumerable<DepartmentDTO> getRecordsList(string filter);

        DepartmentDTO createRecord(DepartmentDTO record);

        DepartmentDTO updateRecord(DepartmentDTO record);

        bool deleteRecordById(int id);
    }
}
