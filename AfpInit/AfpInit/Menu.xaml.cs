using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AfpInit.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfpInit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();

            string iSource=null;

            //Eda.ItemsSource = new List<FoodMenuItem>
            //{
            //    new FoodMenuItem("AfpInit.Images.burger1200300.png") {Name = "Бык Бургер", ImageUrl="AfpInit.Images.burger1200300.png", Price=350},
            //    new FoodMenuItem ("AfpInit.Images.burger2200300.png") {Name = "Гусь Бургер", ImageUrl="AfpInit.Images.burger2200300.png", Price=350}

            //};

            //foodMenuItem.Source = ImageSource.FromResource(iSource);
            
        }
    }
}