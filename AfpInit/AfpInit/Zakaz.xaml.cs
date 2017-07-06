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

        BikBurgerPage _bp;
        SoupPage _sp;
        Sandwich _sand;
        GusBurger _gb;

        public Zakaz(BikBurgerPage bp, SoupPage sp, Sandwich sand, GusBurger gb)
        {
            InitializeComponent();
            InitList();
            BindingContext = this;

            _bp = bp;
            _sp = sp;
            _sand = sand;
            _gb = gb;
            
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
            

            ZakazDetail zakazSender = new ZakazDetail();
            zakazSender.DataSent += OnDataSent;
            await Navigation.PushAsync(zakazSender);
        }

        public void OnDataSent(object source, EventArgs e)
        {

            GusBurger.AllZero(_gb);
            Sandwich.AllZero(_sand);
            SoupPage.AllZero(_sp);
            BikBurgerPage.AllZero(_bp);
        }
    }
}