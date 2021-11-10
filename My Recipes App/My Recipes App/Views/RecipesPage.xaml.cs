using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using My_Recipes_App.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace My_Recipes_App.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class MyRecipesApp : ContentPage
    {
        public MyRecipesApp()
        {
            InitializeComponent();

            BindingContext = new RecipeClass();
        }
        public string ItemId
        {
            set
            {
                Loadrecipe(value);
            }
        }
        async void Loadrecipe(string recipeId)
        {
            try
            {
                int rid = Convert.ToInt32(recipeId);
                RecipeClass recipe = await App.Database.GetRecipeAsync(rid);
                BindingContext = recipe;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var recipe = (RecipeClass)BindingContext;
            if (!string.IsNullOrWhiteSpace(recipe.RecipeTitle))
            {
                await App.Database.SaveRecipeAsync(recipe);
            }

            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var recipe = (RecipeClass)BindingContext;
            await App.Database.DeleteRecipeAsync(recipe);

            await Shell.Current.GoToAsync("..");
        }


    }
}