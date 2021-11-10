using My_Recipes_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using My_Recipes_App.Data;
using System.IO;

namespace My_Recipes_App
{
    public partial class App : Application
    {
        static RecipeDatabase database;

        public static RecipeDatabase Database
        {
            get
            {

                if (database == null)
                {
                    database = new RecipeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recipe.db3"));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
