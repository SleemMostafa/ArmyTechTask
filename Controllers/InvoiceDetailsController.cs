using Microsoft.AspNetCore.Mvc;
using Task_Interview.Models;
using Task_Interview.Repository;
using Task_Interview.ViewModel;

namespace Task_Interview.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private readonly IRepositoryInvoiceDetails repositoryInvoiceDetails;

        public InvoiceDetailsController(IRepositoryInvoiceDetails repositoryInvoiceDetails)
        {
            this.repositoryInvoiceDetails = repositoryInvoiceDetails;
        }
        public IActionResult Index()
        {
            var invoiceDetailsVM = new List<InvoiceDetailsVM>(); 
            var data = repositoryInvoiceDetails.GetAll();
            foreach (var item in data)
            {
                invoiceDetailsVM.Add(new InvoiceDetailsVM
                {
                    Id = item.Id,
                    InvoiceHeaderId = item.InvoiceHeaderId,
                    ItemCount = item.ItemCount,
                    ItemName = item.ItemName,
                    ItemPrice = item.ItemPrice,
                    InvoiceDate = item.InvoiceHeader.Invoicedate,
                    Customer = item.InvoiceHeader.CustomerName
                });
            }
            return View(invoiceDetailsVM);
        }
        public IActionResult GetOne(int id)
        {
            var invoiceDetailsVM = new InvoiceDetailsVM();
            var data = repositoryInvoiceDetails.GetById(id);
            invoiceDetailsVM.Id = data.Id;
            invoiceDetailsVM.ItemCount = data.ItemCount;
            invoiceDetailsVM.ItemName = data.ItemName;
            invoiceDetailsVM.ItemPrice = data.ItemPrice;
            invoiceDetailsVM.InvoiceDate = data.InvoiceHeader.Invoicedate;
            invoiceDetailsVM.Customer = data.InvoiceHeader.CustomerName;
            return View(invoiceDetailsVM);
        }
        public IActionResult Edit(int id)
        {
            var data = repositoryInvoiceDetails.GetById(id);
            return View(data);
        }
        public IActionResult SaveEdit(int id ,InvoiceDetail invoiceDetail)
        {
            var data = repositoryInvoiceDetails.Edit(id, invoiceDetail);
            if(data > 0)
            {
                return RedirectToAction("GetOne", new { id = id });
            }
            return View("Edit"); 
        }
    }
}
