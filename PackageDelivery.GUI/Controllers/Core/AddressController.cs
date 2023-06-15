using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Core;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Core;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Core;
using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Repository.Implementation.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class AddressController : Controller
    {
        private IAddressApplication _app;
        private IMunicipalityApplication _mApp;
        private IPersonApplication _pApp;

        public AddressController(IAddressApplication app, IMunicipalityApplication mApp, IPersonApplication pApp)
        {
            _app = app;
            _mApp = mApp;
            _pApp = pApp;
        }

        public ActionResult Index(string filter = "")
        {
            var dtoList = _app.getRecordList(filter);
            AddressGUIMapper mapper = new AddressGUIMapper();
            IEnumerable<AddressModel> list = mapper.DTOToModelMapper(dtoList);
            return View(list);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel addressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            IEnumerable<MunicipalityDTO> list = _mApp.getRecordsList(string.Empty);
            IEnumerable<PersonDTO> list2 = _pApp.getRecordsList(string.Empty);
            MunicipalityGUIMapper mapper = new MunicipalityGUIMapper();
            PersonGUIMapper mapper2 = new PersonGUIMapper();
            AddressModel model = new AddressModel()
            {
                MunicipioList = mapper.DTOToModelMapper(list),
                PersonaList = mapper2.DTOToModelMapper(list2)
            };

            return View(model);
        }

        // POST: Address/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TipoCalle,Numero,TipoInmueble,Barrio,Observaciones,Actual,idPersona,idMunicipio")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                AddressGUIMapper mapper = new AddressGUIMapper();
                MunicipalityDTO municipality = _mApp.getRecordById(addressModel.IdMunicipio);
                PersonDTO person = _pApp.getRecordById((int)addressModel.IdPersona);
                addressModel.MunicipioName = municipality.Name;
                addressModel.PersonaName = person.FirstName + " " + person.FirstLastname;
                AddressDTO response = _app.createRecord(mapper.ModelToDTOMapper(addressModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(addressModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(addressModel);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel addressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<MunicipalityDTO> mList = this._mApp.getRecordsList(string.Empty);
            IEnumerable<PersonDTO> pList = this._pApp.getRecordsList(string.Empty);
            MunicipalityGUIMapper mMapper = new MunicipalityGUIMapper();
            PersonGUIMapper pMapper = new PersonGUIMapper();
            addressModel.MunicipioList = mMapper.DTOToModelMapper(mList);
            addressModel.PersonaList = pMapper.DTOToModelMapper(pList);
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // POST: Person/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoCalle,Numero,TipoInmueble,Barrio,Observaciones,idPersona,idMunicipio ")] AddressModel addressModel)
        {
            if (ModelState.IsValid)
            {
                AddressGUIMapper mapper = new AddressGUIMapper();
                AddressDTO response = _app.updateRecord(mapper.ModelToDTOMapper(addressModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(addressModel);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressGUIMapper mapper = new AddressGUIMapper();
            AddressModel addressModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (addressModel == null)
            {
                return HttpNotFound();
            }
            return View(addressModel);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool response = _app.deleteRecordById(id);
            if (response)
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View();
        }

    }
}