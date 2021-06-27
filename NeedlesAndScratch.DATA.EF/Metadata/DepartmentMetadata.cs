using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedlesAndScratch.DATA.EF
{
    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department { }

    class DepartmentMetadata
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string DeptName { get; set; }
    }
}
