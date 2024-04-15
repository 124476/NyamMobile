using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public class Rechept
    {
        public int Id { get; set; }
        public int? Num { get; set; }
        public int? BludoId { get; set; }
        public string Text { get; set; }
        public TimeSpan Time { get; set; }

    }
}
