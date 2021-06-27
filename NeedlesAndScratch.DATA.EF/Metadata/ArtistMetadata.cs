using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedlesAndScratch.DATA.EF
{
    [MetadataType(typeof(ArtistMetadata))]
    public partial class Artist
    {
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }

    class ArtistMetadata
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }


        public Nullable<int> Age { get; set; }

        [Required]
        [Display(Name = "Band")]
        public int BandID { get; set; }
    }
}
