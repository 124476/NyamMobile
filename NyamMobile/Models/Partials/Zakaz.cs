using NyamMobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public partial class Zakaz
    {
        public string ClientName
        {
            get
            {
                var client = NetManager.Clients.FirstOrDefault(x => x.Id == ClientId);
                return client.Name;
            }
        }
        public string ColorStatus
        {
            get
            {
                bool st = false;
                string status = "Green";
                foreach (var item in NetManager.ZakazAndBludos)
                {
                    if (item.ZakazId == Id)
                    {
                        if (item.DateStart == null)
                        {
                            st = true;
                            status = "Red";
                        }
                        if (item.DateStart != null && item.DateEnd == null || st && item.DateStart != null)
                        {
                            status = "Yellow";
                            break;
                        }
                    }
                }
                return status;
            }
        }
        public string Dishes
        {
            get
            {
                string dishes = "";
                foreach (var item in NetManager.ZakazAndBludos)
                {
                    if (item.ZakazId == Id)
                    {
                        dishes += NetManager.Bludos.FirstOrDefault(x => x.Id == item.BludoId).Name + ", ";
                    }
                }
                dishes = dishes.Substring(10) + "...";
                return dishes;
            }
        }
        public double TotalCost
        {
            get
            {
                double totalCost = 0;
                foreach (var item in NetManager.ZakazAndBludos)
                {
                    if (item.ZakazId == Id)
                    {
                        totalCost += Double.Parse((NetManager.Bludos.FirstOrDefault(x => x.Id == item.BludoId).Sum * 100).ToString());
                    }
                }
                return totalCost;
            }
        }
    }
}
