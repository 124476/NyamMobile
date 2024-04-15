using NyamMobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public partial class Bludo
    {
        public string TotalTime
        {
            get
            {
                TimeSpan timeSpan = TimeSpan.Zero;
                foreach(var item in NetManager.Rechepts.Where(x => x.BludoId == Id))
                {
                    timeSpan = timeSpan.Add(item.Time);
                }
                
                return timeSpan.TotalMinutes.ToString() + " min.";
            }
        }
    }
}
