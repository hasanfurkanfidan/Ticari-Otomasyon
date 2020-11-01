using Hff.Business.Abstract;
using Hff.Entities.Concrete;
using Hff.MVC.Models.ListViewModels;
using Hff.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hff.MVC.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        private readonly IBillService _billService;
        private readonly IBillLineService _billLineService;
        public BillController(IBillService billService,IBillLineService billLineService)
        {
            _billLineService = billLineService;
            _billService = billService;
        }
        public ActionResult Index()
        {
            var model = new BillListViewModel();
            model.Bills = _billService.GetList();
            return View(model);
        }
        public ActionResult BillView(int id)
        {
            var bill = _billService.GetWithBillLine(id);
            var model = new BillWithBillLineViewModel();
            model.BillId = id;
            model.BillLines = bill.BillLines;
            model.Deliverer = bill.Deliverer;
            model.Date = bill.Date;
            model.Hour = bill.Hour;
            model.RowNumber = bill.RowNumber;
            model.TaxAdministration = bill.TaxAdministration;
            model.Receiver = bill.Receiver;
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var model = new BillAddViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(BillAddViewModel model)
        {
            _billService.Create(new Bill { Date = model.Date, SerialNumber = model.SerialNumber, RowNumber = model.RowNumber, Deliverer = model.Deliverer, Receiver = model.Receiver, TaxAdministration = model.TaxAdministration, Hour = model.Hour });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var bill = _billService.GetById(id);
            return View(BillWithBillLineViewModel.From(bill));
        }
        [HttpPost]
        public ActionResult Update(BillWithBillLineViewModel model)
        {
            var bill = _billLineService.GetById(model.BillId);
            _billService.Update(BillWithBillLineViewModel.To(model));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddBillLine(int id)
        {
            var bill = _billService.GetById(id);
            var model = new BillLineAddViewModel();
            model.BillId = bill.BillId;
            return View(model);

        }
        [HttpPost]
        public ActionResult AddBillLine(BillLineAddViewModel model)
        {
            _billLineService.Create(new BillLine
            {
                BillId = model.BillId,
                Description = model.Description,
                Price = model.Price,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                
            });
            return Redirect("/Bill/BillView/" + model.BillId);
        }
    }
}