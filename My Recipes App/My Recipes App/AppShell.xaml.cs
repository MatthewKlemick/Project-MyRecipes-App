using Xamarin.Forms;
using My_Recipes_App.Views;

namespace My_Recipes_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MyRecipesApp), typeof(MyRecipesApp));

        }
    }
}
