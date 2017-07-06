using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfpInit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZakazDetail : ContentPage
    {
        private const string url = "http://web-atom.ru/mail.php";
        private HttpClient _client = new HttpClient();
        private string _name;
        private string _tel;

        public delegate void DataSentEventHandler(object source, EventArgs args);
        public event DataSentEventHandler DataSent;

        protected virtual void OnDataSent()
        {
            if (DataSent != null)
            {
                DataSent(this, EventArgs.Empty);
            }
        }

        public ZakazDetail()
        {
            InitializeComponent();
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Post();
            //await DisplayAlert("ПОЧТИ ГОТОВО", "Ваш Заказ на сумму " + Order.OrderTotal + " руб. был отправлен нам на кухню. Мы перезвоним Вам в течении 10 мин для подтверждения." ,"Крутяк!");
            DisplayAlert("ПОЧТИ ГОТОВО", "Ваш Заказ на сумму " + Order.OrderTotal + " руб. был отправлен нам на кухню. Мы перезвоним Вам в течении 10 мин для подтверждения.", "Крутяк!");
            OnDataSent();
            GoBack();
        }

        async void GoBack()
        {
            await Navigation.PushAsync(new IntroPage());
        }

        async void Post()
        {
            var parameters = new Dictionary<string, string>
            {
                { "param1", " Срочно бросить на сковородку " },
                { "param2", " Бык Бургер: " + Order.CountBik.ToString() },
                { "param3", " Гусь Бургер: " + Order.CountGus.ToString()  },
                { "param4", " Сэндвич Ребра: " + Order.CountSand.ToString()  },
                { "param5", " Супец: " + Order.CountFo.ToString()  },
                { "param6", " Имя: "+_name },
                { "param7", " Телефон: "+_tel.ToString() },
                { "param8", " Сумма Заказа: "+Order.OrderTotal.ToString() }
            };
          
            var encodedContent = new FormUrlEncodedContent(parameters);
            var response = await _client.PostAsync(url, encodedContent);

        }

        //tel
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _tel = e.NewTextValue;
        }

        //name
        private void Entry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            _name = e.NewTextValue;
        }
    }
}