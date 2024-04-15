using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Kol { get; set; }
        public double Sum { get; set; }
        public int? UnitId { get; set; }
    }
}
