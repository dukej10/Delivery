using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Implementation.Implementation.Core;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Core;
using PackageDelivery.GUI.Models.Parameters;
using PackageDelivery.Repository.Contracts.DbModels.Parameters;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class PackageController : Controller
    {
        private IPackageApplication _app = new PackageImpApplication();
        private IOfficeApplication _oApp = new OfficeImpApplication();

        public PackageController(IPackageApplication app, IOfficeApplication oApp) 
        {
            _app = app;
            _oApp = oApp;
        }

        // GET: Package
        // GET: Package
        public ActionResult Index(string filter = "")
        {
            var dtoList = _app.getRecordsList(filter);
            PackageGUIMapper mapper = new PackageGUIMapper();
            IEnumerable<PackageModel> list = mapper.DTOToModelMapper(dtoList);
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
            PackageModel packageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (packageModel == null)
            {
                return HttpNotFound();
            }
            return View(packageModel);
        }

        // GET: Package/Create
        public ActionResult Create()
        {
            IEnumerable<OfficeDTO> list = _oApp.getRecordsList(string.Empty);
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            PackageModel model = new PackageModel()
            {
                OfficeList = mapper.DTOToModelMapper(list)
            };

            return View(model);
        }

        // POST: Package/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Weight,Height,Depth,Width,IdOffice")] PackageModel packageModel)
        {
            if (ModelState.IsValid)
            {
                PackageGUIMapper mapper = new PackageGUIMapper();
                OfficeDTO offi = _oApp.getRecordById(packageModel.IdOffice);
                packageModel.IdOffice = offi.Id;
                PackageDTO response = _app.createRecord(mapper.ModelToDTOMapper(packageModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(packageModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(packageModel);
        }

        // GET: Package/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageGUIMapper mapper = new PackageGUIMapper();
            PackageModel packageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<OfficeDTO> oList = this._oApp.getRecordsList(string.Empty);
            OfficeGUIMapper oMapper = new OfficeGUIMapper();
            packageModel.OfficeList = oMapper.DTOToModelMapper(oList);
            if (packageModel == null)
            {
                return HttpNotFound();
            }
            return View(packageModel);
        }

        // POST: Package/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Height,Depth,Width,IdOffice")] PackageModel packageModel)
        {
            if (ModelState.IsValid)
            {
                PackageGUIMapper mapper = new PackageGUIMapper();
                PackageDTO response = _app.updateRecord(mapper.ModelToDTOMapper(packageModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(packageModel);
        }

        // GET: Package/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageGUIMapper mapper = new PackageGUIMapper();
            PackageModel packageModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (packageModel == null)
            {
                return HttpNotFound();
            }
            return View(packageModel);
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
