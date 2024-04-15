using NyamMobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public partial class ZakazAndBludo
    {
        public bool CanCooking
        {
            get
            {
                if (DateStart != null)
                {
                    return true;
                }
                return false;
            }
        }
        public bool DontCanCooking
        {
            get
            {
                if (DateStart == null)
                {
                    return true;
                }
                return false;
            }
        }
        public string TimeBludo
        {
            get
            {
                return NetManager.Bludos.FirstOrDefault(x => x.Id == BludoId).TotalTime;
            }
        }
        public string BaseServingsName
        {
            get
            {
                return NetManager.Bludos.FirstOrDefault(x => x.Id == BludoId).BaseServings.ToString();
            }
        }
        public string Name
        {
            get
            {
                return NetManager.Bludos.FirstOrDefault(x => x.Id == BludoId).Name.ToString();
            }
        }
        public string ProcessDescription
        {
            get
            {
                if (DateStart == null)
                {
                    return "В ожидании";
                }
                if (DateEnd == null)
                {
                    return "В процессе";
                }
                return "Завершен";
            }
        }
        public int Num
        {
            get
            {
                int nm = 1;
                var zac = NetManager.Zakazs.FirstOrDefault(x => x.Id == ZakazId);
                foreach (var item in NetManager.ZakazAndBludos.Where(x => x.ZakazId == zac.Id))
                {
                    if (item.Id == Id)
                    {
                        break;
                    }
                    nm++;
                }

                return nm;
            }
        }
    }
}
