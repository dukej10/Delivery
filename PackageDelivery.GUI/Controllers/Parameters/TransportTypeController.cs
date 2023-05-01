using System;
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
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Models;
using PackageDelivery.GUI.Models.Parameters;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class TransportTypeController : Controller
    {
        private ITransportTypeApplication _app = new TransportTypeImpApplication();

        // GET: TransportType
        public ActionResult Index(string filter = "")
        {
            return View(_app.getRecordsList(filter));
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportGUIMapper mapper = new TransportGUIMapper();
            TransportTypeModel transportTypeDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeDTO == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeDTO);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] TransportTypeModel transportTypeDTO)
        {
            if (ModelState.IsValid)
            {
                TransportGUIMapper mapper = new TransportGUIMapper();
                TransportTypeDTO response = _app.createRecord(mapper.ModelToDTOMapper(transportTypeDTO));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(transportTypeDTO);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(transportTypeDTO);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportGUIMapper mapper = new TransportGUIMapper();
            TransportTypeModel transportTypeDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeDTO == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeDTO);
        }

        // POST: Person/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,OtherNames,FirstLastname,SecondLastname,IdentificationNumber,Cellphone,Email,IdentificationType")] TransportTypeModel transportTypeDTO)
        {
            if (ModelState.IsValid)
            {
                TransportGUIMapper mapper = new TransportGUIMapper();
                TransportTypeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(transportTypeDTO));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(transportTypeDTO);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportGUIMapper mapper = new TransportGUIMapper();
            TransportTypeModel transportTypeDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (transportTypeDTO == null)
            {
                return HttpNotFound();
            }
            return View(transportTypeDTO);
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
