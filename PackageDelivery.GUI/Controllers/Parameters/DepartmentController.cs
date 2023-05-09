using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.Application.Implementation.Implementation.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Parameters
{
    public class DepartmentController : Controller
    {
        private IDepartmentApplication _app = new DepartmentImpApplication();

        // GET: DepartmentModels
        public ActionResult Index(string filter = "")
        {
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            IEnumerable<DepartmentModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: DepartmentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel DepartmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DepartmentModel == null)
            {
                return HttpNotFound();
            }
            return View(DepartmentModel);
        }

        // GET: DepartmentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                DepartmentGUIMapper mapper = new DepartmentGUIMapper();
                DepartmentDTO response = _app.createRecord(mapper.ModelToDTOMapper(departmentModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(departmentModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(departmentModel);
        }

        // GET: DepartmentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel DepartmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DepartmentModel == null)
            {
                return HttpNotFound();
            }
            return View(DepartmentModel);
        }

        // POST: DepartmentModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DepartmentModel DepartmentModel)
        {
            if (ModelState.IsValid)
            {
                DepartmentGUIMapper mapper = new DepartmentGUIMapper();
                DepartmentDTO response = _app.updateRecord(mapper.ModelToDTOMapper(DepartmentModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(DepartmentModel);
        }

        // GET: DepartmentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentGUIMapper mapper = new DepartmentGUIMapper();
            DepartmentModel DepartmentModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (DepartmentModel == null)
            {
                return HttpNotFound();
            }
            return View(DepartmentModel);
        }

        // POST: DepartmentModels/Delete/5
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
