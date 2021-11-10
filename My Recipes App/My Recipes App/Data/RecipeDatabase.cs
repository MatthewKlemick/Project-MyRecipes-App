using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using My_Recipes_App.Models;
using System.Threading.Tasks;

namespace My_Recipes_App.Data
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public RecipeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<RecipeClass>().Wait();
        }
        public Task<List<RecipeClass>> GetRecipesAsync()
        {
            return database.Table<RecipeClass>().ToListAsync();
        }
        public Task<RecipeClass> GetRecipeAsync(int rid)
        {
            return database.Table<RecipeClass>().Where(i => i.RecipeID == rid).FirstOrDefaultAsync();
        }
        public Task<int> SaveRecipeAsync(RecipeClass recipe)
        {
            if (recipe.RecipeID != 0)
            {
                return database.UpdateAsync(recipe);
            }
            else
            {
                return database.InsertAsync(recipe);
            }
        }
        public Task<int> DeleteRecipeAsync(RecipeClass recipe)
        {
            return database.DeleteAsync(recipe);
        }
    }
}
