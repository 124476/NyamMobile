using NyamMobile.Models;
using NyamMobile.Service;

namespace NyamMobile
{
    public partial class App : Application
    {

        
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyBludo.json"), NetManager.BludoPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyZakaz.json"), NetManager.ZakazPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyZakazAndBludo.json"), NetManager.ZakazAndBludoPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyOneRechept.json"), NetManager.OneRecheptPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyMainInit.json"), NetManager.MainInitPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyIngredient.json"), NetManager.IngredientPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyRechept.json"), NetManager.RecheptPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyCategory.json"), NetManager.CategoryPath);
            NetManager.DataInit(Path.Combine(FileSystem.Current.AppDataDirectory, "copyClient.json"), NetManager.ClientPath);
        }
    }
}
