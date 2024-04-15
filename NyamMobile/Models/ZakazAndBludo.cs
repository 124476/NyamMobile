using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public partial class ZakazAndBludo
    {
        public int Id { get; set; }
        public int? BludoId { get; set; }
        public int? ZakazId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

    }
}
