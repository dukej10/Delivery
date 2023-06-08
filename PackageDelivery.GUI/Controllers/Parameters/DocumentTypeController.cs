﻿using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using DocumentTypeImpApplication = PackageDelivery.Application.Implementation.Implementation.Parameters.DocumentTypeImpApplication;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class DocumentTypeController : Controller
    {
        private IDocumentTypeApplication _app;

        //private IDocumentTypeApplication _app;
        public DocumentTypeController(IDocumentTypeApplication app)
        {
            this._app = app;
        }

        // GET: DocumentTypeModels
        public ActionResult Index(string filter = "")
        {
            DocumentTypeGUIMapper mapper = new DocumentTypeGUIMapper();
            IEnumerable<DocumentTypeModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: DocumentTypeModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentTypeGUIMapper mapper = new DocumentTypeGUIMapper();
            DocumentTypeModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // GET: DocumentTypeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentTypeModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DocumentTypeModel documentTypeModel)
        {
            if (ModelState.IsValid)
            {
                DocumentTypeGUIMapper mapper = new DocumentTypeGUIMapper();
                DocumentTypeDTO response = _app.createRecord(mapper.ModelToDTOMapper(documentTypeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(documentTypeModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(documentTypeModel);
        }

        // GET: DocumentTypeModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentTypeGUIMapper mapper = new DocumentTypeGUIMapper();
            DocumentTypeModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // POST: DocumentTypeModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DocumentTypeModel documentTypeModel)
        {
            if (ModelState.IsValid)
            {
                DocumentTypeGUIMapper mapper = new DocumentTypeGUIMapper();
                DocumentTypeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(documentTypeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(documentTypeModel);
        }

        // GET: DocumentTypeModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentTypeGUIMapper mapper = new DocumentTypeGUIMapper();
            DocumentTypeModel documentTypeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (documentTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(documentTypeModel);
        }

        // POST: DocumentTypeModels/Delete/5
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
