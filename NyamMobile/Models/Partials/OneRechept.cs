using NyamMobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Models
{
    public partial class OneRechept
    {
        public double SumIng
        {
            get
            {
                double sumIng = 0;
                Rechept rechept = NetManager.Rechepts.FirstOrDefault(x => x.Id == RecheptId);
                Bludo bludo = NetManager.Bludos.FirstOrDefault(x => x.Id == rechept.BludoId);
                foreach (var item in NetManager.Rechepts)
                {
                    if (item.BludoId == bludo.Id)
                    {
                        foreach (var itemm in NetManager.OneRechepts.Where(x => x.RecheptId == item.Id))
                        {
                            if (itemm.IngredientId == IngredientId)
                            {
                                sumIng += Double.Parse(itemm.Kol.ToString());
                            }
                        }
                    }
                }
                return sumIng;
            }
        }
        public string MainInitName
        {
            get
            {
                return NetManager.MainInits.FirstOrDefault(x => x.Id == MainInitId).Name;
            }
        }
        public double SumName
        {
            get
            {
                return NetManager.Ingredients.FirstOrDefault(x => x.Id == IngredientId).Sum;
            }
        }
        public string IngredientName
        {
            get
            {
                return NetManager.Ingredients.FirstOrDefault(x => x.Id == IngredientId).Name;
            }
        }
    }
}
