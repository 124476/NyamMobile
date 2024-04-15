using Microsoft.Maui.Controls.Platform;
using Newtonsoft.Json;
using NyamMobile.Models;
using NyamMobile.Service;

namespace NyamMobile.Pages;

public partial class OknoOrders : ContentPage
{
	public OknoOrders()
	{
		InitializeComponent();
		ListOrders.ItemsSource = NetManager.Zakazs.ToList();
    }

    private void ListOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Zakaz zakaz = ListOrders.SelectedItem as Zakaz;
        if (zakaz != null)
        {
            var IsCan = false;
            if (zakaz.ColorStatus == "Yellow"){
                foreach (var item in NetManager.ZakazAndBludos)
                {
                    if (item.ZakazId == zakaz.Id) {

                        Bludo bludo = NetManager.Bludos.FirstOrDefault(x => x.Id == item.ZakazId);
                        foreach (var itemm in NetManager.OneRechepts)
                        {
                            if (NetManager.Rechepts.FirstOrDefault(x => x.Id == itemm.RecheptId).BludoId == bludo.Id && itemm.SumIng < NetManager.Ingredients.FirstOrDefault(x => x.Id == itemm.IngredientId).Kol)
                            {
                                IsCan = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (IsCan)
            {
                Navigation.PushModalAsync(new OknoIngredients(zakaz));
            }
            else
            {
                Navigation.PushModalAsync(new OknoOrderDishes(zakaz));
            }
        }
    }
}