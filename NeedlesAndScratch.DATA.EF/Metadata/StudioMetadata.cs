using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedlesAndScratch.DATA.EF
{
    [MetadataType(typeof(StudioMetadata))]
    public partial class Studio
    {
        public string StudioInfo
        {
            get
            {
                return $"Studio City: {StudioCity}, Studio State: {StudioState}, Studio Country {StudioCountry}";
            }
        }
    }

    class StudioMetadata
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Studio Name")]
        public string StudioName { get; set; }

        [Required]
        [Display(Name = "Studio State")]
        public string StudioState { get; set; }

        [Required]
        [Display(Name = "Studio City")]
        public string StudioCity { get; set; }

        [Required]
        [Display(Name = "Studio Country")]
        public string StudioCountry { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime YearFounded { get; set; }
    }
}
