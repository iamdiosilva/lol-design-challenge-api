using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.Domain.Entities.Base;

namespace DesafioLoldesign.API.Domain.Entities
{
    public class Plans : BaseEntity
    {
        
        public string Name { get; private set; }
        public decimal Tax { get; private set; }
        public double Time { get; private set; }

        public Plans(string name, decimal tax, double time)
        {
            Name = name;
            Tax = tax;
            Time = time;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateTax(decimal tax)
        {
            Tax = tax;
        }

        public void UpdateTime(double time)
        {
            Time = time;
        }
    }
}