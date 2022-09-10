using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioLoldesign.API.ViewModels.Requests
{
    public class RegisterRatesRequest
    {
        [Required]
        public int DddOrigin { get; set; }
        [Required]
        public int DddDestiny { get; set; }
        [Required]
        public decimal PricePerMinute { get; set; }
    }
}