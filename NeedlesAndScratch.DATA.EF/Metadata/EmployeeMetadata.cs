using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedlesAndScratch.DATA.EF
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }

    class EmployeeMetadata
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Required]
        [Display(Name = "Reports To")]
        public int ReportsTo { get; set; }

        [Required]
        [Display(Name = "Department ID")]
        public int DeptID { get; set; }
    }
}
