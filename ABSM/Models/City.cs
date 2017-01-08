using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABSM.Models
{
    public class City
    {
        public int CityID { get; set; }

        [Display(Name ="City")]
        public string CityName { get; set; }
    }
}