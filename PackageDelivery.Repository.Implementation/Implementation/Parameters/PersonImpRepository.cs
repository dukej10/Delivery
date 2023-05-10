using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using PackageDelivery.Repository.Contracts.Interfaces;
using PackageDelivery.Repository.Implementation.DataModel;
using PackageDelivery.Repository.Implementation.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.Repository.Implementation.Implementation.Parameters
{
    public class PersonImpRepository : IPersonRepository
    {
        public PersonDbModel createRecord(PersonDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                persona docType = db.persona.Where(x => x.correo.ToUpper().Trim().Equals(record.Email.ToUpper())).FirstOrDefault();
                if (docType != null)
                {
                    return null;
                }
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                persona dt = mapper.DbModelToDatabaseMapper(record);
                db.persona.Add(dt);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(dt);
            }
        }

        public bool deleteRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                try
                {
                    persona record = db.persona.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.persona.Remove(record);
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
        public PersonDbModel getRecordById(int id)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                persona record = db.persona.Find(id);
                if (record == null)
                {
                    return null;
                }
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Buscar la lista de registros
        /// </summary>
        /// <param name="filter">Filtro a aplicar en la lista</param>
        /// <returns>Lista de registros filtrados</returns>
        public IEnumerable<PersonDbModel> getRecordsList(string filter)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                IEnumerable<persona> list = db.persona.Where(x => x.correo.Contains(filter));
                PersonRepositoryMapper mapper = new PersonRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        public PersonDbModel updateRecord(PersonDbModel record)
        {
            using (PackageDeliveryEntities db = new PackageDeliveryEntities())
            {
                persona td = db.persona.Where(x => x.id == record.Id).FirstOrDefault();
                if (td == null)
                {
                    return null;
                }
                else
                {
                    td.primerNombre = record.FirstName;
                    td.otrosNombres = record.OtherNames;
                    td.primerApellido = record.FirstLastname;
                    td.segundoApellido = record.SecondLastname;
                    td.documento = record.IdentificationNumber;
                    td.telefono = record.PhoneNumber;
                    db.Entry(td).State = EntityState.Modified;
                    db.SaveChanges();
                    PersonRepositoryMapper mapper = new PersonRepositoryMapper();

                    return mapper.DatabaseToDbModelMapper(td);
                }
            }
        }
    }
}
