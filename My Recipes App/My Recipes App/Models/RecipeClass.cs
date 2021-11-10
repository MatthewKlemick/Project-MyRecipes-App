using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace My_Recipes_App.Models
{
    public class RecipeClass
    {
        [PrimaryKey, AutoIncrement]
        public int RecipeID { get; set; }
        public string RecipeTitle { get; set; }
        public string RecipeBy { get; set; }
        public string RecipeIngred { get; set; }
        public string RecipeSteps { get; set; }
    }
}
