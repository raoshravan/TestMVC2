using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class ViewModel
    {
        public IEnumerable<MvcDemo.DataDb.AllDepartment_Result> Departments { get; set; }  

        public MvcDemo.DataDb.AllEmployeeswithDp_Result Emp = new MvcDemo.DataDb.AllEmployeeswithDp_Result();
    }
}