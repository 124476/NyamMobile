using Newtonsoft.Json;
using NyamMobile.Models;
using NyamMobile.Service;

namespace NyamMobile.Pages;

public partial class OknoRecipe : ContentPage
{
    ZakazAndBludo contextBludo;
    public OknoRecipe(ZakazAndBludo zakazAndBludo)
	{
		InitializeComponent();
        Bludo bludo = NetManager.Bludos.FirstOrDefault(x => x.Id == zakazAndBludo.BludoId);
        ContentMain.Title = "Recipe for " + bludo.Name;
        BaseServing.Text = bludo.BaseServings.ToString();
        Num.Text = zakazAndBludo.Num.ToString();
        TTime.Text = zakazAndBludo.TimeBludo.ToString();

        contextBludo = zakazAndBludo;
        List<OneRechept> ings = new List<OneRechept>();

        foreach (var item in NetManager.Rechepts.Where(x => x.BludoId == bludo.Id))
        {
            foreach (var itemm in NetManager.OneRechepts.Where(x => x.RecheptId == item.Id))
            {
                Ingredient ing = NetManager.Ingredients.FirstOrDefault(x => x.Id == itemm.IngredientId);
                if (NetManager.Rechepts.FirstOrDefault(x => x.Id == itemm.RecheptId).BludoId == bludo.Id && itemm.SumIng < ing.Kol)
                {
                    if (ings.FirstOrDefault(x => x.IngredientId == itemm.IngredientId) == null)
                    {
                        ings.Add(itemm);
                    }
                }
            } 
        }
        ListIngredients.ItemsSource = ings;
        ListProcess.ItemsSource = NetManager.Rechepts.Where(x => x.BludoId == bludo.Id).OrderBy(x => x.Num);
    }

    private void FinishBtn_Clicked(object sender, EventArgs e)
    {
        contextBludo.DateEnd = DateTime.Now;

        File.WriteAllText(NetManager.CopyZakazAndBludoPath, JsonConvert.SerializeObject(NetManager.ZakazAndBludos.ToList()));
        Navigation.PushModalAsync(new OknoOrders());
    }
}