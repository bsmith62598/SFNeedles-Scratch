using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NeedlesAndScratch.DATA.EF;
using System.ComponentModel.DataAnnotations;

namespace NeedlesAndScratch.UI.Secured.Models
{
    //We created this ViewModel to combine domain-related data (Books) with other information (int Qty) -- Since we're combining different types of information, this is technically a ViewModel


    public class CartItemViewModel
    {
        [Range(1, int.MaxValue)]
        public int Qty { get; set; }

        public Record Product { get; set; }
        
        public CartItemViewModel(int qty, Record product)
        {
            Qty = qty;
            Product = product;
        }
    }
}