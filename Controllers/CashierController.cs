using Microsoft.AspNetCore.Mvc;
using Task_Interview.Models;
using Task_Interview.Repository;

namespace Task_Interview.Controllers
{
    public class CashierController : Controller
    {
        private readonly IRepositoryCashier repositoryCashier;
        private readonly IRepositoryBranch repositoryBranch;

        public CashierController(IRepositoryCashier repositoryCashier,IRepositoryBranch repositoryBranch)
        {
            this.repositoryCashier = repositoryCashier;
            this.repositoryBranch = repositoryBranch;
        }
        public IActionResult Index()
        {
            return View(repositoryCashier.GetAll());
        }
        public IActionResult GetOne(int id)
        {
            var data = repositoryCashier.GetById(id);
            return View(data);
        }
        public IActionResult Add()
        {
            var branches = repositoryBranch.GetAll();
            ViewData["Branchs"] = branches;
            return View();
        }
        public IActionResult SaveAdd(Cashier newCasheir)
        {
            var rwoEffect = repositoryCashier.Insert(newCasheir);
            if (rwoEffect > 0)
            {
                return RedirectToAction("index");
            }
            
            var branches = repositoryBranch.GetAll();
            ViewData["Branchs"] = branches;
            return View("Add",newCasheir);
        }
        public IActionResult Edit(int id)
        {
            var branches = repositoryBranch.GetAll();
            ViewData["Branchs"] = branches;
            var data = repositoryCashier.GetById(id);
                return View(data);
        }
        public IActionResult SaveEdit(int id,Cashier newCasheir)
        {
                var rwoEffect = repositoryCashier.Edit(id,newCasheir);
                if (rwoEffect > 0)
                {
                    return RedirectToAction("GetOne", new {id = newCasheir.Id});
                }
            return View("Edit",new {id=id});
        }
        public IActionResult Delete(int id)
        {
            var data = repositoryCashier.Delete(id);
            return RedirectToAction("index");
        }
    }
}
