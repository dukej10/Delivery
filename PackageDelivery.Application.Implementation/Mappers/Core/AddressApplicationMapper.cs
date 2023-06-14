using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Implementation.Mappers;
using PackageDelivery.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;

namespace PackageDelivery.Repository.Implementation.Mappers.Core
{
    internal class AddressApplicationMapper : DTOMapperBase<AddressDTO, AddressDbModel>
    {

        public override AddressDTO DbModelToDTOMapper(AddressDbModel input)
        {
            return new AddressDTO()
            {
                Id = input.Id,
                TipoCalle = input.TipoCalle,
                Numero = input.Numero,
                TipoInmueble = input.TipoInmueble,
                Barrio = input.Barrio,
                Observaciones = input.Observaciones,
                Actual = input.Actual,
                IdMunicipio = input.IdMunicipio,
                IdPersona = input.IdPersona,
                MunicipioName = input.MunicipioName,
                PersonaName = input.PersonaName

            };
        }

        public override IEnumerable<AddressDTO> DbModelToDTOMapper(IEnumerable<AddressDbModel> input)
        {
            IList<AddressDTO> list = new List<AddressDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override AddressDbModel DTOToDbModelMapper(AddressDTO input)
        {
            return new AddressDbModel()
            {
                Id = input.Id,
                TipoCalle = input.TipoCalle,
                Numero = input.Numero,
                TipoInmueble = input.TipoInmueble,
                Barrio = input.Barrio,
                Observaciones = input.Observaciones,
                Actual = input.Actual,
                IdMunicipio = input.IdMunicipio,
                IdPersona = input.IdPersona,
                MunicipioName = input.MunicipioName,
                PersonaName = input.PersonaName

            };
        }

        public override IEnumerable<AddressDbModel> DTOToDbModelMapper(IEnumerable<AddressDTO> input)
        {
            IList<AddressDbModel> list = new List<AddressDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
