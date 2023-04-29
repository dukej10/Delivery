﻿using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class MunicipalityImpRepository : IMunicipalityRepository
    {
        public MunicipalityDbModel createRecord(MunicipalityDbModel record)
        {
            throw new NotImplementedException();
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    municipio record = db.municipio.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.municipio.Remove(record);
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
        public MunicipalityDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                municipio record = db.municipio.Find(id);
                if (record == null)
                {
                    return null;
                }
                MunicipalityRepositoryMapper mapper = new MunicipalityRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<MunicipalityDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<municipio> list = db.municipio.Where(x => x.nombre.Contains(filter));
                MunicipalityRepositoryMapper mapper = new MunicipalityRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public MunicipalityDbModel updateRecord(MunicipalityDbModel record)
        {
            throw new NotImplementedException();
        }
    }
}
