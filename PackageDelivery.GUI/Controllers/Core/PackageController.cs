using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Implementation.Core;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Models.Core;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class PackageController : Controller
    {
        private IPackageApplication _app = new PackageImpApplication();
        // GET: Package
        // GET: Package
        public ActionResult Index(string filter = "")
        {
            PackageGUIMapper mapper = new PackageGUIMapper();
            IEnumerable<PackageModel> list = mapper.DTOToModelMapper(_app.getRecordsList(filter));
            return View(list);
        }

        // GET: Package/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageGUIMapper mapper = new PackageGUIMapper();
            PackageModel packageDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (packageDTO == null)
            {
                return HttpNotFound();
            }
            return View(packageDTO);
        }

        // GET: Package/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Package/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Weight,Height,Depth,Width,IdOffice")] PackageModel packageDTO)
        {
            if (ModelState.IsValid)
            {
                PackageGUIMapper mapper = new PackageGUIMapper();
                PackageDTO response = _app.createRecord(mapper.ModelToDTOMapper(packageDTO));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(packageDTO);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(packageDTO);
        }

        // GET: Package/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageGUIMapper mapper = new PackageGUIMapper();
            PackageModel packageDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (packageDTO == null)
            {
                return HttpNotFound();
            }
            return View(packageDTO);
        }

        // POST: Package/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Height,Depth,Width,IdOffice")] PackageModel packageDTO)
        {
            if (ModelState.IsValid)
            {
                PackageGUIMapper mapper = new PackageGUIMapper();
                PackageDTO response = _app.updateRecord(mapper.ModelToDTOMapper(packageDTO));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(packageDTO);
        }

        // GET: Package/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageGUIMapper mapper = new PackageGUIMapper();
            PackageModel packageDTO = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (packageDTO == null)
            {
                return HttpNotFound();
            }
            return View(packageDTO);
        }

        // POST: Package/Delete/5
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
