using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioLoldesign.API.ViewModels.Reponses
{
    public class PlanResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Tax { get; set; }
        public double Time { get; set; }
    }
}