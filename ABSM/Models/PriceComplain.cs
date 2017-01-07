using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABSM.Models
{
    public class PriceComplain
    {
        public int ID { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Display(Name= "Expected Price")]
        public int ExpectedPrice { get; set; }

        [Required]
        public int ShopID { get; set; }

        public Product Product { get; set; }

        public Shop Shop { get; set; }
    }
}