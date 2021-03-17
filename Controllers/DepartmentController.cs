using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DataContext _Db;
        public DepartmentController(DataContext db)
        {
            _Db = db;

        }
        public IActionResult Index()
        {
            return View(_Db.tbl_Department.ToList());
        }

        public IActionResult Create(Department obj)
        {
            
            return View(obj);
        }
        public  async Task<IActionResult> AddDepartment(Department obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _Db.tbl_Department.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }

            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult>DeleteDep(int id)
        {
            try
            {
                var dep = await _Db.tbl_Department.FindAsync(id);
                if (dep != null)
                {
                    _Db.tbl_Department.Remove(dep);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

       
    }
}