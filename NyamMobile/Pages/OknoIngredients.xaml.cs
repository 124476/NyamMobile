using NyamMobile.Models;
using NyamMobile.Service;

namespace NyamMobile.Pages;

public partial class OknoIngredients : ContentPage
{
	public OknoIngredients(Zakaz zakaz)
	{
		InitializeComponent();
        List<OneRechept> listStock = new List<OneRechept>();
        List<OneRechept> listAvailable = new List<OneRechept>();
        double totalAva = 0;
        double totalStock = 0;
        foreach (var item in NetManager.ZakazAndBludos)
        {
            if (item.ZakazId == zakaz.Id)
            {

                Bludo bludo = NetManager.Bludos.FirstOrDefault(x => x.Id == item.ZakazId);

                foreach (var itemm in NetManager.OneRechepts)
                {
                    Ingredient ing = NetManager.Ingredients.FirstOrDefault(x => x.Id == itemm.IngredientId);
                    if (NetManager.Rechepts.FirstOrDefault(x => x.Id == itemm.RecheptId).BludoId == bludo.Id && itemm.SumIng < ing.Kol)
                    {
                        if (listAvailable.FirstOrDefault(x => x.IngredientId == itemm.IngredientId) == null){
                            listAvailable.Add(itemm);
                            totalAva += Double.Parse((itemm.SumIng * ing.Kol).ToString());
                        }
                    }
                    else
                    {
                        if (listStock.FirstOrDefault(x => x.IngredientId == itemm.IngredientId) == null)
                        {
                            listStock.Add(itemm);
                            totalStock += Double.Parse((itemm.SumIng * ing.Kol).ToString());
                        }
                    }
                }
            }
        }
        TotalAva.Text = totalAva.ToString();
        TotalStock.Text = totalStock.ToString();

        ListStock.ItemsSource = listStock;
        ListAvailable.ItemsSource = listAvailable;
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new OknoOrders());
    }
}