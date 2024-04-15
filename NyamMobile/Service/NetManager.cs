
using Newtonsoft.Json;
using NyamMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyamMobile.Service
{
    public class NetManager
    {
        public static readonly string BludoPath = "jsonBludo.json";
        public static readonly string CategoryPath = "jsonCategory.json";
        public static readonly string ClientPath = "jsonClient.json";
        public static readonly string IngredientPath = "jsonIngredient.json";
        public static readonly string MainInitPath = "jsonMainInit.json";
        public static readonly string OneRecheptPath = "jsonOneRechept.json";
        public static readonly string ZakazPath = "jsonZakaz.json";
        public static readonly string ZakazAndBludoPath = "jsonZakazAndBludo.json";

        public static readonly string RecheptPath = "jsonRechept.json";
        public static string CopyBludoPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyBludo.json"); }
        public static string CopyCategoryPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyCategory.json"); }
        public static string CopyClientPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyClient.json"); }
        public static string CopyIngredientPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyIngredient.json"); }
        public static string CopyMainInitPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyMainInit.json"); }
        public static string CopyOneRecheptPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyOneRechept.json"); }
        public static string CopyZakazPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyZakaz.json"); }
        public static string CopyZakazAndBludoPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyZakazAndBludo.json"); }
        public static string CopyRecheptPath { get => Path.Combine(FileSystem.Current.AppDataDirectory, "copyRechept.json"); }

        private static List<Bludo> bludos;

        public static List<Bludo> Bludos
        {
            get
             {
                if (bludos == null)
                {
                    bludos = GetData<List<Bludo>>(CopyBludoPath);
                }
                return bludos;
            }
            set
            {
                bludos = value;
                SetData<List<Bludo>>(CopyBludoPath, bludos);
            }
        }

        private static List<Category> categories;

        public static List<Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    categories = GetData<List<Category>>(CopyCategoryPath);
                }
                return categories;
            }
            set
            {
                categories = value;
                SetData<List<Category>>(CopyCategoryPath, categories);
            }
        }

        private static List<Ingredient> ingredients;

        public static List<Ingredient> Ingredients
        {
            get
            {
                if (ingredients == null)
                {
                    ingredients = GetData<List<Ingredient>>(CopyIngredientPath);
                }
                return ingredients;
            }
            set
            {
                ingredients = value;
                SetData<List<Ingredient>>(CopyIngredientPath, ingredients);
            }
        }


        private static List<Rechept> rechepts;

        public static List<Rechept> Rechepts
        {
            get
            {
                if (rechepts == null)
                {
                    rechepts = GetData<List<Rechept>>(CopyRecheptPath);
                }
                return rechepts;
            }
            set
            {
                rechepts = value;
                SetData<List<Rechept>>(CopyRecheptPath, rechepts);
            }
        }

        private static List<MainInit> mainInits;

        public static List<MainInit> MainInits
        {
            get
            {
                if (mainInits == null)
                {
                    mainInits = GetData<List<MainInit>>(CopyMainInitPath);
                }
                return mainInits;
            }
            set
            {
                mainInits = value;
                SetData<List<MainInit>>(CopyMainInitPath, mainInits);
            }
        }

        private static List<OneRechept> oneRechepts;

        public static List<OneRechept> OneRechepts
        {
            get
            {
                if (oneRechepts == null)
                {
                    oneRechepts = GetData<List<OneRechept>>(CopyOneRecheptPath);
                }
                return oneRechepts;
            }
            set
            {
                oneRechepts = value;
                SetData<List<OneRechept>>(CopyOneRecheptPath, oneRechepts);
            }
        }

        private static List<ZakazAndBludo> zakazAndBludos;

        public static List<ZakazAndBludo> ZakazAndBludos
        {
            get
            {
                if (zakazAndBludos == null)
                {
                    zakazAndBludos = GetData<List<ZakazAndBludo>>(CopyZakazAndBludoPath);
                }
                return zakazAndBludos;
            }
            set
            {
                zakazAndBludos = value;
                SetData<List<ZakazAndBludo>>(CopyZakazAndBludoPath, zakazAndBludos);
            }
        }

        private static List<Zakaz> zakazs;

        public static List<Zakaz> Zakazs
        {
            get
            {
                if (zakazs == null)
                {
                    zakazs = GetData<List<Zakaz>>(CopyZakazPath);
                }
                return zakazs;
            }
            set
            {
                zakazs = value;
                SetData<List<Zakaz>>(CopyZakazPath, zakazs);
            }
        }

        private static List<Client> clients;

        public static List<Client> Clients
        {
            get
            {
                if (clients == null)
                {
                    clients = GetData<List<Client>>(CopyClientPath);
                }
                return clients;
            }
            set
            {
                clients = value;
                SetData<List<Client>>(CopyClientPath, clients);
            }
        }


        private static void SetData<T>(string copyBludoPath, T bludos)
        {
            var jsondata = JsonConvert.SerializeObject(bludos);
            File.WriteAllText(jsondata, copyBludoPath);
        }

        private static T GetData<T>(string copyBludoPath)
        {
            var data = JsonConvert.DeserializeObject<T>(File.ReadAllText(copyBludoPath));
            return data;
        }

        internal static async void DataInit(string output, string source)
        {
            if(!File.Exists(output))
            {
                var file = File.Create(output);
                file.Close();
                File.WriteAllText(output, await ReaderAsset(source));
            }
        }

        private static async Task<string?> ReaderAsset(string source)
        {
            using(var stream = await FileSystem.OpenAppPackageFileAsync(source))
            {
                using(var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
