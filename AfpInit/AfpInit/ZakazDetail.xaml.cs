using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfpInit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZakazDetail : ContentPage
    {
        public ZakazDetail()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("ЗАКАЗ ОТПРАВЛЕН", "Ваш Заказ на сумму" + Order.OrderTotal + " руб. был отправлен. Мы перезвоним Вам в течении 10 мин для подтверждения." ,"Крутяк!");

        }
    }
}