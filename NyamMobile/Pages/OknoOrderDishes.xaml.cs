using NyamMobile.Models;
using NyamMobile.Service;

namespace NyamMobile.Pages;

public partial class OknoOrderDishes : ContentPage
{
	public OknoOrderDishes(Zakaz zakaz)
	{
		InitializeComponent();
        ListDishes.ItemsSource = NetManager.ZakazAndBludos.Where(x => x.ZakazId == zakaz.Id).ToList();
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new OknoOrders());
    }

    private void Start_Clicked(object sender, EventArgs e)
    {
        ZakazAndBludo zakazAndBludo = (sender as Button).BindingContext as ZakazAndBludo;
        if (zakazAndBludo != null)
        {
            zakazAndBludo.DateStart = DateTime.Now;
            Navigation.PushModalAsync(new OknoRecipe(zakazAndBludo));
        }
    }
}