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
    public partial class Zakaz : ContentPage
    {
        public string WordCount { get { return "Ваш Заказ " + Order.OrderTotal + " руб"; } }

        public Zakaz()
        {
            InitializeComponent();
            InitList();
            BindingContext = this;
        }



        void InitList()
        {
            listZakaza.ItemsSource = new List<FoodMenuItem>
            {
                new FoodMenuItem {Name="Бык Бургер", Quantity=Order.CountBik, PriceTotal=Order.CountBik*350},
                new FoodMenuItem {Name="Гусь Бургер", Quantity=Order.CountGus, PriceTotal=Order.CountGus*350},
                new FoodMenuItem {Name="Суп Фо", Quantity=Order.CountFo, PriceTotal=Order.CountFo*350},
                new FoodMenuItem {Name="Сэндвич Ребра", Quantity=Order.CountSand, PriceTotal=Order.CountSand*350}
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            GoToEnterData();
        }

        async void GoToEnterData()
        {
            await Navigation.PushAsync(new ZakazDetail());
        }
    }
}