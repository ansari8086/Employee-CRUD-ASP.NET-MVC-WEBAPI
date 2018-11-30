using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Mvc.Models
{
    public class MvcEmployeeModel
    {
        public int Id { get; set; }
        
    [Required(ErrorMessage="This field is require")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmpCode { get; set; }
        public string Designation { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}