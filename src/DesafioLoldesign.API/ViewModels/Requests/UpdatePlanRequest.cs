using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioLoldesign.API.ViewModels.Requests
{
    public class UpdatePlanRequest
    {   
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public double Time { get; set; }
    }
}