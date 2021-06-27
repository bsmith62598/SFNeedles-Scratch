using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedlesAndScratch.DATA.EF
{
    [MetadataType(typeof(BandMetadata))]
    public partial class Band { }

    class BandMetadata
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Band")]
        public string BandName { get; set; }

        [Display(Name = "Year Founded")]
        public Nullable<System.DateTime> Founded { get; set; }

        [Required]
        [Display(Name = "Still Active?")]
        public bool IsActive { get; set; }
       
    }
}
