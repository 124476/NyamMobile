using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public partial class Bludo
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Opisanie { get; set; }
        public float? Sum { get; set; }
        [JsonIgnore]
        public byte[] Photo { get; set; }
        public string Sslka { get; set; }
        public int? BaseServings { get; set; }

       

    }
}
