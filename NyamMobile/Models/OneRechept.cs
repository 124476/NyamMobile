using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public partial class OneRechept
    {
        public int Id { get; set; }
        public int? RecheptId { get; set; }
        public int? IngredientId { get; set; }
        public double? Kol { get; set; }
        public int? MainInitId { get; set; }

    }
}
