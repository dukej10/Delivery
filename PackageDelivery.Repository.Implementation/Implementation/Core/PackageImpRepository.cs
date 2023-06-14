using PackageDelivery.Repository.Contracts.DbModels.Core;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageDelivery.Repository.Implementation.Implementation.Core
{
    public class PackageImpRepository : IPackageRepository
    {
        public PackageDbModel createRecord(PackageDbModel record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    paquete record = db.paquete.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.paquete.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>null cuando no lo encuentra o el objeto cuando si lo encuentra</returns>
        public PackageDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                paquete record = db.paquete.Find(id);
                if (record == null)
                {
                    return null;
                }
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PackageDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<paquete> list = db.paquete.Where(x => x.idOficina.ToString().Contains(filter));
                PackageRepositoryMapper mapper = new PackageRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public PackageDbModel updateRecord(PackageDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
