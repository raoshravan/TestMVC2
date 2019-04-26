using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
using System.Dynamic;
using PagedList;
using PagedList.Mvc;

namespace MvcDemo.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index(int deptId)
        {
            var db = new DataDb.SampleEntities();
            List<MvcDemo.DataDb.AllEmployeeswithDp_Result> mylist = db.AllEmployeeswithDp().Where(emp => emp.DepartmentId == deptId).ToList();
            return View(mylist);
        }
        public ActionResult Details(int Id)
        {
            var db = new DataDb.SampleEntities();
            return View(db.AllEmployeeswithDp().Single(emp => emp.EmployeeId == Id));
        }
        public ActionResult ShowAll()
        {
            var db = new DataDb.SampleEntities();           
            return View(db.AllEmployeeswithDp().ToList());
 
        }
        public ActionResult Create()
        {
            //var db = new DataDb.SampleEntities();
            //MvcDemo.Models.ViewModel mymodel = new ViewModel();
            //mymodel.Departments = db.AllDepartment().ToList();
            //return View(mymodel);

            var db = new DataDb.SampleEntities();
            List<MvcDemo.DataDb.AllDepartment_Result> Depts = db.AllDepartment().ToList();
            ViewBag.Deptlist = new SelectList(Depts, "Id", "Name");    
            return View();
        }

        public ActionResult Delete()
        {
            var db = new DataDb.SampleEntities();
            List<MvcDemo.DataDb.AllEmployeeswithDp_Result> mylist = db.AllEmployeeswithDp().ToList();
            return View(mylist);
        }

        public ActionResult DeleteEntry(int id)
        {
            var db = new DataDb.SampleEntities();
            if (ModelState.IsValid)  //from kudvenkat lec 15 //id != null
            {     
                db.DeleteData(id);
            
            }
            var dbn = new DataDb.SampleEntities();            
            return RedirectToAction("Delete"); // direct Delete method call nai hota from kudvenkat lec 13
            //List<MvcDemo.DataDb.AllEmployeeswithDp_Result> mylist = dbn.AllEmployeeswithDp().ToList();
            //View("Delete",mylist);

        }

        [HttpGet]
        public ActionResult DeleteMultiple()
        {
            var db = new DataDb.SampleEntities();
            return View(db.AllEmployeeswithDp().ToList());
        }

        [HttpPost]
        [ActionName("DeleteMultiple")]
        public ActionResult DeleteMultiple_Post(IEnumerable<int> EmployeesToDelete)
        {
            var db = new DataDb.SampleEntities();
            foreach (var id in EmployeesToDelete)
            {
                if (ModelState.IsValid)  //from kudvenkat lec 15 //id != null
                {
                    db.DeleteData(id);
                }
            }
            var dbn = new DataDb.SampleEntities();
            return View(dbn.AllEmployeeswithDp().ToList());
        }
        // [HttpGet]
        //public ActionResult InsertData()
        //{
        //    var db = new DataDb.SampleEntities();
        //    List<MvcDemo.DataDb.AllDepartment_Result> Depts =db.AllDepartment().ToList();

        //    ViewBag.Deptlist = new SelectList(Depts, "Id", "Name");
        //    return View("Create");
        //}

        [HttpPost]
        [ActionName("InsertData")]
        public ActionResult InsertData_Post(MvcDemo.DataDb.AllEmployeeswithDp_Result emp)
        {
            var db = new DataDb.SampleEntities();
            //TryUpdateModel(emp);
            if (ModelState.IsValid)     //from lec 15 kudvenkat  //emp.EmployeeId != null
            {
                db.InsertData(emp.Name, emp.Gender, (int)emp.DepartmentId, emp.City,emp.EmailId,emp.Salary,emp.PersonalWebsite);
            }
            return RedirectToAction("ShowAll"); // direct ShowAll method call nai hota from kudvenkats lec 13
            // var db = new DataDb.SampleEntities();
            //List<MvcDemo.DataDb.AllEmployeeswithDp_Result> mylist = db.AllEmployeeswithDp().ToList();
            // return View("ShowAll", mylist);
        }
        [HttpGet]
        public ActionResult EditEntry(int Id)
        {
            var db = new DataDb.SampleEntities();
            List<MvcDemo.DataDb.AllDepartment_Result> Depts = db.AllDepartment().ToList();
            ViewBag.Departmentlist = new SelectList(Depts, "Id", "Name");  
            return View(db.AllEmployeeswithDp().Single(emp => emp.EmployeeId == Id));
        }

        [HttpPost]
        [ActionName("EditEntry")]   //part 20
        public ActionResult EditEntry_Post(int Id)
        {
            
            var db = new DataDb.SampleEntities();
            MvcDemo.DataDb.AllEmployeeswithDp_Result emp = db.AllEmployeeswithDp().Single(empId => empId.EmployeeId == Id);  //part 20
            UpdateModel(emp, null, null, new String[] { "EmployeeId" });    //part 20 part 21 specifies alternate method using Bind attribute. Model binding using interfaces in part 22
            if (ModelState.IsValid)
            {
                db.updateEmployee(emp.EmployeeId, emp.Name, emp.Gender, emp.City, emp.DepartmentId);
            }
            return RedirectToAction("ShowAll"); 
        }

        public ActionResult TableSorter()
        {

            return View();
        }
    }
}       
//public ActionResult ShowAll(string searchBy,string search,int ? page , string sortBy )
//        {
//            var db = new DataDb.SampleEntities();
//            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) || sortBy == "NameAscending" ? "NameDescending" : "NameAscending";
//            var employees = db.AllEmployeeswithDp().ToList().AsQueryable();  //to list done to remove error the result of a query cannot be enumerated more than once
//            if (searchBy == "Name" || searchBy == null )
//            {
//                if (search == null)
//                { }
//                //return View("ShowAll", db.AllEmployeeswithDp().ToList().ToPagedList(page ?? 1, 4));  
//                else
//                    employees = employees.Where(employee => employee.Name.StartsWith(search, true, null));
//                    //return View("ShowAll", db.AllEmployeeswithDp().Where(employee => employee.Name.StartsWith(search, true, null)).ToList().ToPagedList(page ?? 1,4));
//                switch(sortBy)
//                {
//                    case "NameDescending":
//                        employees = employees.OrderByDescending(employee => employee.Name);
//                        break;
//                    case "NameAscending":
//                        employees = employees.OrderBy(employee => employee.Name);
//                        break;
//                    default:
//                        employees = employees.OrderBy(employee => employee.Name);
//                        break;
//                }
//                return View(employees.ToPagedList(page ?? 1, 4));
//            }
//            else
//            {
//                if(search == null)
//                    return View("ShowAll", db.AllEmployeeswithDp().ToList().ToPagedList(page ?? 1, 4));
//                else
//                    return View("ShowAll", db.AllEmployeeswithDp().Where(employee => employee.DepartmentName.StartsWith(search, true, null)).ToList().ToPagedList(page ?? 1, 4));
//            }
//        }
