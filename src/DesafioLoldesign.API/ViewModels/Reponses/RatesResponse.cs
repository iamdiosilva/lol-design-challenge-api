using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioLoldesign.API.ViewModels.Reponses
{
    public class RatesResponse
    {
        public Guid Id { get; set; }
        public int DddOrigin { get; set; }
        public int DddDestiny { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}