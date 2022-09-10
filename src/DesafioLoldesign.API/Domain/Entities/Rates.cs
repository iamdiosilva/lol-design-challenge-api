using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.Domain.Entities.Base;

namespace DesafioLoldesign.API.Domain.Entities
{
    public class Rates : BaseEntity
    {
        public Rates(int dddOrigin, int dddDestiny, decimal pricePerMinute)
        {
            DddOrigin = dddOrigin;
            DddDestiny = dddDestiny;
            PricePerMinute = pricePerMinute;
        }

        public int DddOrigin { get; private set; }
        public int DddDestiny { get; private set; }
        public decimal PricePerMinute { get; private set; }

        public void UpdateDddOrigin(int dddOrigin)
        {
            DddOrigin = dddOrigin;
        }

        public void UpdateDddDestiny(int dddDestiny)
        {
            DddDestiny = dddDestiny;
        }

        public void UpdatePricePerMinute(decimal pricePerMinute)
        {
            PricePerMinute = pricePerMinute;
        }
        
    }
}