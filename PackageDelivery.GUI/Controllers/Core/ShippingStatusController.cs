using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Implementation.Core;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Core;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
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
    public class ShippingStatusController : Controller
    {
        private IShippingStatusApplication _app = new ShippingStatusImpApplication();

        // GET: ShippingStatus
        public ActionResult Index(string filter = "")
        {
            ShippingStatusGUIMapper mapper = new ShippingStatusGUIMapper();
            IEnumerable<ShippingStatusModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: ShippingStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingStatusGUIMapper mapper = new ShippingStatusGUIMapper();
            ShippingStatusModel shippingStatusDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (shippingStatusDTO == null)
            {
                return HttpNotFound();
            }
            return View(shippingStatusDTO);
        }

        // GET: ShippingStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingStatus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ShippingStatusModel shippingStatusModel)
        {
            if (ModelState.IsValid)
            {
                ShippingStatusGUIMapper mapper = new ShippingStatusGUIMapper();
                ShippingStatusDTO response = _app.createRecord(mapper.ModelToDTOMapper(shippingStatusModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(shippingStatusModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(shippingStatusModel);
        }

        // GET: ShippingStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingStatusGUIMapper mapper = new ShippingStatusGUIMapper();
            ShippingStatusModel shippingStatusModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (shippingStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(shippingStatusModel);
        }

        // POST: Person/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name")] ShippingStatusModel shippingStatusModel)
        {
            if (ModelState.IsValid)
            {
                ShippingStatusGUIMapper mapper = new ShippingStatusGUIMapper();
                ShippingStatusDTO response = _app.updateRecord(mapper.ModelToDTOMapper(shippingStatusModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(shippingStatusModel);
        }

        // GET: ShippingStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingStatusGUIMapper mapper = new ShippingStatusGUIMapper();
            ShippingStatusModel shippingStatusModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (shippingStatusModel == null)
            {
                return HttpNotFound();
            }
            return View(shippingStatusModel);
        }

        // POST: ShippingStatus/Delete/5
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