using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
namespace MvcDemo.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/

        public ActionResult Index()
        {
            var db = new DataDb.SampleEntities();
            List<MvcDemo.DataDb.AllDepartment_Result> mylist = db.AllDepartment().ToList();
            return View(mylist);
        }
        public ActionResult DepartmentTotal()       //part 29 from kudvenkat
        {
            var db = new DataDb.SampleEntities();
            var employeeList=db.tblEmployees.Include("Department").GroupBy(x => x.tblDepartment.Name).Select(y => new DepartmentTotal
            {
                Name = y.Key,
                Total = y.Count()
            }).ToList().OrderByDescending(y => y.Total);
            return View(employeeList);
        }
            /*Equivalent sql query leaving out the order by is like
                * SELECT [dbo].[tblDepartment].Name,COUNT(*) AS Total
                FROM [dbo].[tblEmployee]
                JOIN [dbo].[tblDepartment]
                ON [dbo].[tblDepartment].Id=[dbo].[tblEmployee].DepartmentId
                GROUP BY [dbo].[tblDepartment].Name
                Go  */

    }
}
