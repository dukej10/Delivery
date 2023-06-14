using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.GUI.Implementation.Mappers;
using PackageDelivery.GUI.Models.Core;
using System;
using System.Collections.Generic;

namespace PackageDelivery.GUI.Implementation.Mappers.Core
{
    internal class AddressGUIMapper : ModelMapperBase<AddressModel, AddressDTO>
    {

        public override AddressModel DTOToModelMapper(AddressDTO input)
        {
            return new AddressModel()
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

        public override IEnumerable<AddressModel> DTOToModelMapper(IEnumerable<AddressDTO> input)
        {
            IList<AddressModel> list = new List<AddressModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override AddressDTO ModelToDTOMapper(AddressModel input)
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

        public override IEnumerable<AddressDTO> ModelToDTOMapper(IEnumerable<AddressModel> input)
        {
            IList<AddressDTO> list = new List<AddressDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
