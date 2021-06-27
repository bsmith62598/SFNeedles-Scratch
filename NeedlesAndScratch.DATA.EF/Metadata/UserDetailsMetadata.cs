using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedlesAndScratch.DATA.EF
{
    [MetadataType(typeof(UserDetailMetadata))]
    public partial class UserDetail { }

    class UserDetailMetadata
    {
        public string UserID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        [Display(Name = "Favorite Genre. Optional")]
        public string FavGenre { get; set; }
        
        [Display(Name = "Favorite Band. Optional")]
        public string FavBand { get; set; }
    }
}
