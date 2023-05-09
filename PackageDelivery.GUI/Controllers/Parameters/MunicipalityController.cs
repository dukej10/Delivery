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
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models;
using PackageDelivery.GUI.Models.Parameters;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class MunicipalityController : Controller
    {
        private IMunicipalityApplication  _app = new MunicipalityImpApplication();

        // GET: Municipality
        // GET: MunicipalityModels
        public ActionResult Index(string filter = "")
        {
            MunicipalityGUIMapper mapper = new MunicipalityGUIMapper();
            IEnumerable<MunicipalityModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: MunicipalityModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalityGUIMapper mapper = new MunicipalityGUIMapper();
            MunicipalityModel MunicipalityModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (MunicipalityModel == null)
            {
                return HttpNotFound();
            }
            return View(MunicipalityModel);
        }

        // GET: MunicipalityModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MunicipalityModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MunicipalityModel MunicipalityModel)
        {
            if (ModelState.IsValid)
            {
                MunicipalityGUIMapper mapper = new MunicipalityGUIMapper();
                MunicipalityDTO response = _app.createRecord(mapper.ModelToDTOMapper(MunicipalityModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
                return View(MunicipalityModel);
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(MunicipalityModel);
        }

        // GET: MunicipalityModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalityGUIMapper mapper = new MunicipalityGUIMapper();
            MunicipalityModel MunicipalityModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (MunicipalityModel == null)
            {
                return HttpNotFound();
            }
            return View(MunicipalityModel);
        }

        // POST: MunicipalityModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MunicipalityModel MunicipalityModel)
        {
            if (ModelState.IsValid)
            {
                MunicipalityGUIMapper mapper = new MunicipalityGUIMapper();
                MunicipalityDTO response = _app.updateRecord(mapper.ModelToDTOMapper(MunicipalityModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(MunicipalityModel);
        }

        // GET: MunicipalityModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MunicipalityGUIMapper mapper = new MunicipalityGUIMapper();
            MunicipalityModel MunicipalityModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (MunicipalityModel == null)
            {
                return HttpNotFound();
            }
            return View(MunicipalityModel);
        }

        // POST: MunicipalityModels/Delete/5
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
