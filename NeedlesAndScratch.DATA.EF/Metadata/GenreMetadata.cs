using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedlesAndScratch.DATA.EF
{
    [MetadataType(typeof(GenreMetadata))]
    public partial class Genre { }

    class GenreMetadata
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
}
