﻿using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Implementation.Core;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class OfficeController : Controller
    {
        private IOfficeApplication _app = new OfficeImpApplication();
        // GET: Office
        // GET: Office
        public ActionResult Index(string filter = "")
        {
            return View(_app.getRecordsList(filter));
        }

        // GET: Office/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel officeDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (officeDTO == null)
            {
                return HttpNotFound();
            }
            return View(officeDTO);
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Office/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,Phone,Latitude,Longitude,Address,IdMunicipality")] OfficeModel officeDTO)
        {
            if (ModelState.IsValid)
            {
                OfficeGUIMapper mapper = new OfficeGUIMapper();
                OfficeDTO response = _app.createRecord(mapper.ModelToDTOMapper(officeDTO));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(officeDTO);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(officeDTO);
        }

        // GET: Office/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel officeDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (officeDTO == null)
            {
                return HttpNotFound();
            }
            return View(officeDTO);
        }

        // POST: Office/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,Phone,Latitude,Longitude,Address,IdMunicipality")] OfficeModel officeDTO)
        {
            if (ModelState.IsValid)
            {
                OfficeGUIMapper mapper = new OfficeGUIMapper();
                OfficeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(officeDTO));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(officeDTO);
        }

        // GET: Office/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel officeDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (officeDTO == null)
            {
                return HttpNotFound();
            }
            return View(officeDTO);
        }

        // POST: Office/Delete/5
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
