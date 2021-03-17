using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _Db;
        public StudentController(DataContext Db)
        {
            _Db = Db;
        }
        public IActionResult Index()
        {
            try
            {
                var stdlist = from a in _Db.tbl_Student
                              join b in _Db.tbl_Department
                              on a.DepId equals b.ID
                              into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Student
                              {
                                  ID = a.ID,
                                  Name = a.Name,
                                  Email = a.Email,
                                  CellNo = a.CellNo,
                                  DepId = a.DepId,
                                  Department = b == null ? "" : b.DepartmentName
                              };
                return View(stdlist);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public  IActionResult Create(Student obj)
        {
            loadDDL();
            return View(obj);
        }

        public async Task<IActionResult> AddStudent(Student obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _Db.tbl_Student.Add(obj);
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

        public async Task<IActionResult> DeleteStd(int id)
        {
            try
            {
                var std = await _Db.tbl_Student.FindAsync(id);
                if (std != null)
                {
                    _Db.tbl_Student.Remove(std);
                    await _Db.SaveChangesAsync();

                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }
        private void loadDDL()
        {
            try
            {
                List<Department> depList = new List<Department>();
                depList = _Db.tbl_Department.ToList();
                depList.Insert(0, new Department { ID = 0, DepartmentName = "Please select the department" });


                ViewBag.Deplist = depList;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}