using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.MvcBusiness
{
    public class BizLayer
    {
        public List<MvcDemo.DataDb.AllEmployees_Result> GetEntity() 
        {
            var db = new DataDb.SampleEntities();

            List<MvcDemo.DataDb.AllEmployees_Result> mylist = db.AllEmployees().ToList();

            return mylist;
        }

    }
}