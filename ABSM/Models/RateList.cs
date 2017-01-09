using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABSM.Models
{
    public class RateList
    {
        public int ID { get; set; }

        [Required, Display(Name ="Category")]
        public int CategoryID { get; set; }

        [Required, Display(Name = "Product")]
        public int ProductID { get; set; }

        [Required]
        public int Price { get; set; }

        [Required, Display(Name = "City")]
        public int CityID { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }

        //Navigational Propperties

        public Product Product { get; set; }

        public Category Category { get; set; }

        public City City { get; set; }
    }
}