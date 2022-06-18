using LaboratorioAzure.Data;
using LaboratorioAzure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioAzure.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = _context.Employees.Where(s=>s.Estate == true);
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["ResultOk"] = "Record added successfully!";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null || id <= 0) 
            {
                return NotFound();
            }
            var employee = _context.Employees.Find(id);

            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["ResultOk"] = "Data Updated Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);

        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var employee = _context.Employees.Find(id);
                if(employee == null)
                {
                    return NotFound();
                }
                employee.Estate = false;
                _context.Employees.Update(employee);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data deleted successfully"; 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
