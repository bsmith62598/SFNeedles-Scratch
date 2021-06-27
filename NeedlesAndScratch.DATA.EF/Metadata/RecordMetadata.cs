using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedlesAndScratch.DATA.EF
{
    [MetadataType(typeof(RecordMetadata))]
    public partial class Record { }

    class RecordMetadata
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Record Name")]
        public string RecordName { get; set; }


        public int Tracks { get; set; }


        public int Length { get; set; }

        [Display(Name = "Year Recorded")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public Nullable<DateTime> YearRecorded { get; set; }


        public string RecordCover { get; set; }

        [Required]
        [Display(Name = "Stock Status")]
        public int StockStatus { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }

        [Required]
        [Display(Name = "Band")]
        public int BandID { get; set; }

        [Required]
        [Display(Name = "Studio")]
        public int StudioID { get; set; }

        [DisplayFormat(DataFormatString ="{0:c}")]
        public Nullable<decimal> Price { get; set; }
    }
}
