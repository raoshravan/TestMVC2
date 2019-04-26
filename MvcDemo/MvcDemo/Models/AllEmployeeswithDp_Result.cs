using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.DataDb
{
    [MetadataType(typeof(AllEmployeeswithDp))]
    public partial class AllEmployeeswithDp_Result
    {

    }
    
    public  class AllEmployeeswithDp
    {
        [DisplayFormat(NullDisplayText = "Name not specified")]
        public string Name { get; set; }

        [DisplayFormatAttribute(NullDisplayText = "Gender not specified",ConvertEmptyStringToNull=true,ApplyFormatInEditMode=true)]
        public string Gender { get; set; }


        [DisplayFormat(NullDisplayText = "City not specified")]
        public string City { get; set; }


        [DisplayFormat(NullDisplayText = "DepartmentId not specified")]
        public Nullable<int> DepartmentId { get; set; }


        [DisplayFormat(NullDisplayText = "EmailId not specified")]
        public string EmailId { get; set; }


        [DisplayFormat(NullDisplayText = "Salary not specified")]
        public Nullable<int> Salary { get; set; }

        [DataType(DataType.Url)]
        [DisplayFormat(NullDisplayText = "PersonalWebsite not specified")]
        public string PersonalWebsite { get; set; }


        [DisplayFormat(NullDisplayText = "DepartmentName not specified")]
        public string DepartmentName { get; set; }
    }
}