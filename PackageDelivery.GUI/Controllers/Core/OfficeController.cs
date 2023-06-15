using Microsoft.Reporting.WebForms;
using PackageDelivery.Application.Contracts.DTO;
using PackageDelivery.Application.Contracts.Interfaces.Core;
using PackageDelivery.Application.Contracts.Interfaces.Parameters;
using PackageDelivery.GUI.Helpers;
using PackageDelivery.GUI.Implementation.Mappers.Parameters;
using PackageDelivery.GUI.Mappers.Core;
using PackageDelivery.GUI.Mappers.Parameters;
using PackageDelivery.GUI.Models.Core;
using PackageDelivery.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PackageDelivery.GUI.Controllers.Core
{
    public class OfficeController : Controller
    {
        private IOfficeApplication _app;
        private IMunicipalityApplication _mApp;
        public OfficeController(IOfficeApplication app, IMunicipalityApplication mApp)
        {
            _app = app;
            _mApp = mApp;
        }

        // GET: Office
        // GET: Office
        public ActionResult Index(string filter = "")
        {
            var dtoList = _app.getRecordsList(filter);
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            IEnumerable<OfficeModel> list = mapper.DTOToModelMapper(dtoList);
            return View(list);
        }

        // GET: Office/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel officeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (officeModel == null)
            {
                return HttpNotFound();
            }
            return View(officeModel);
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            IEnumerable<MunicipalityDTO> list = _mApp.getRecordsList(string.Empty);
            MunicipalityGUIMapper mapper = new MunicipalityGUIMapper();
            OfficeModel model = new OfficeModel()
            {
                MunicipalityList = mapper.DTOToModelMapper(list)
            };
            return View(model);
        }

        // POST: Office/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,Phone,Latitude,Longitude,Address,IdMunicipality")] OfficeModel officeModel)
        {
            if (ModelState.IsValid)
            {
                OfficeGUIMapper mapper = new OfficeGUIMapper();
                MunicipalityDTO munic = _mApp.getRecordById(officeModel.IdMunicipality);
                officeModel.IdMunicipality = munic.Id;
                OfficeDTO response = _app.createRecord(mapper.ModelToDTOMapper(officeModel));
                if (response != null)
                {
                    ViewBag.ClassName = ActionMessages.successClass;
                    ViewBag.Message = ActionMessages.successMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.ClassName = ActionMessages.warningClass;
                ViewBag.Message = ActionMessages.alreadyExistsMessage;
                return View(officeModel);
            }
            ViewBag.ClassName = ActionMessages.warningClass;
            ViewBag.Message = ActionMessages.errorMessage;
            return View(officeModel);
        }

        // GET: Office/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel officeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            IEnumerable<MunicipalityDTO> mList = this._mApp.getRecordsList(string.Empty);
            MunicipalityGUIMapper dtMapper = new MunicipalityGUIMapper();
            officeModel.MunicipalityList = dtMapper.DTOToModelMapper(mList);
            if (officeModel == null)
            {
                return HttpNotFound();
            }
            return View(officeModel);
        }

        // POST: Office/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,Phone,Latitude,Longitude,Address,IdMunicipality")] OfficeModel officeModel)
        {
            if (ModelState.IsValid)
            {
                OfficeGUIMapper mapper = new OfficeGUIMapper();
                OfficeDTO response = _app.updateRecord(mapper.ModelToDTOMapper(officeModel));
                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ErrorMessage = "Error ejecutando la acción";
            return View(officeModel);
        }

        // GET: Office/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            OfficeModel officeModel = mapper.DTOToModelMapper(_app.getRecordById(id.Value));
            if (officeModel == null)
            {
                return HttpNotFound();
            }
            return View(officeModel);
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

        public ActionResult Office_Report(string format = "PDF")
        {
            var list = _app.getRecordsList(string.Empty);
            OfficeGUIMapper mapper = new OfficeGUIMapper();
            List<OfficeModel> recordsList = mapper.DTOToModelMapper(list).ToList();
            string reportPath = Server.MapPath("~/Reports/rdlcFiles/OfficesReport.rdlc");
            //List<string> dataSets = new List<string> { "CustomerList" };
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource res = new ReportDataSource("OfficesList", recordsList);
            lr.DataSources.Add(res);


            renderedBytes = lr.Render(
            format,
            string.Empty,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings
            );

            return File(renderedBytes, mimeType);
        }
    }
}
