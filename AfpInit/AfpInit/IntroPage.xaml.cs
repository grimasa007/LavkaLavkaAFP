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
    public partial class IntroPage : ContentPage
    {

        public IntroPage()
        {
            InitializeComponent();
            //lavkaBg.Source = ImageSource.FromResource("AfpInit.Images.bg.png");
            lavkaLogo.Source = ImageSource.FromResource("AfpInit.Images.lavkaLogo.png");
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GusBurger());
        }

    }
}