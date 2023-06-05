﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Models;
using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using DocumentTypeImpApplication = PackageDelivery.Application.Implementation.Implementation.Parameters.DocumentTypeImpApplication;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class PersonController : Controller
    {

        private IPersonApplication _app = new PersonImpApplication();
        private IDocumentTypeApplication _dtApp = new DocumentTypeImpApplication();
        // GET: Person
        // GET: Person
        public ActionResult Index(string filter = "")
        {
            var dtoList = _app.getRecordsList(filter);
            PersonGUIMapper mapper = new PersonGUIMapper();
            IEnumerable<PersonModel> list = mapper.DTOToModelMapper(dtoList);
            return View(list);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel personModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            IEnumerable<DocumentTypeDTO> list = _dtApp.getRecordsList(string.Empty);
            DocumentTypeGUIMapper mapper = new DocumentTypeGUIMapper();
            PersonModel model = new PersonModel()
            {
                DocumentTypeList = mapper.DTOToModelMapper(list)
            };

            return View(model);
        }

        // POST: Person/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                PersonGUIMapper mapper = new PersonGUIMapper();
                DocumentTypeDTO document = _dtApp.getRecordById(personModel.IdentificationType);
                personModel.DocumentTypeName = document.Name;
                PersonDTO response = _app.createRecord(mapper.ModelToDTOMapper(personModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(personModel);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(personModel);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel personModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<DocumentTypeDTO> dtList = this._dtApp.getRecordsList(string.Empty);
            DocumentTypeGUIMapper dtMapper = new DocumentTypeGUIMapper();
            personModel.DocumentTypeList = dtMapper.DTOToModelMapper(dtList);
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
        }

        // POST: Person/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                PersonGUIMapper mapper = new PersonGUIMapper();
                PersonDTO response = _app.updateRecord(mapper.ModelToDTOMapper(personModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(personModel);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonGUIMapper mapper = new PersonGUIMapper();
            PersonModel personModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (personModel == null)
            {
                return HttpNotFound();
            }
            return View(personModel);
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
