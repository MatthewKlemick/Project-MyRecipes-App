using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using My_Recipes_App.Models;
using My_Recipes_App.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Collections;

namespace My_Recipes_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UIDefiner : ContentPage
    {
        public UIDefiner()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.Database.GetRecipesAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MyRecipesApp));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                RecipeClass recipe = (RecipeClass)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(MyRecipesApp)}?{nameof(MyRecipesApp.ItemId)}={recipe.RecipeID.ToString()}");
            }
        }
    }
}