using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public partial class Zakaz
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public int? ClientId { get; set; }
    }
}
