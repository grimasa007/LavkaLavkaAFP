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
    public partial class SoupPage : ContentPage
    {
        private int _soupCounter;
        private AbsoluteLayout _layout;
        private Label _howMany;
        private Label _itemName = new Label();
        private Button _buttonSubtract;
        private Button _buttonAdd;
        private Label _total;
        private Label _name;

        public SoupPage()
        {
            InitializeComponent();
            CreateLayout();
            SetFoodImage();
            SetCart();
            SetCheckOut();
            SetItemName();


        }


        void SetLeftBox()
        {
            var box = new BoxView { Color = Color.Brown };
            box.Opacity = 0.7;
            _layout.Children.Add(box,
                                new Rectangle(0, 0, 0.3, 0.7),
                                AbsoluteLayoutFlags.All);
        }

        void CreateLayout()
        {
            _layout = new AbsoluteLayout();
            Content = _layout;
        }

        void SetFoodImage()
        {
            var img = new Image { Source = ImageSource.FromResource("AfpInit.Images.sup.jpg"), Aspect = Aspect.AspectFill };
            _layout.Children.Add(img,
                                new Rectangle(0, 0, 1, 0.7),
                                AbsoluteLayoutFlags.All);
        }

        void SetCart()
        {
            var img = new Image { Source = ImageSource.FromResource("AfpInit.Images.cart.png"), Aspect = Aspect.AspectFill };
            _layout.Children.Add(img,
                                new Rectangle(0.5, 0.92, 50, 50),
                                AbsoluteLayoutFlags.PositionProportional);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                SetSubtractButton();
                SetAddButton();
                _layout.Children.Remove(img);
                _soupCounter++;
                Order.OrderTotal += 350;
                SetItemCount();
                InsertText();
            };
            img.GestureRecognizers.Add(tapGestureRecognizer);

        }

        async void GoToCart()
        {
            await Navigation.PushAsync(new Zakaz());
        }

        void SetCheckOut()
        {
            var img = new Image { Source = ImageSource.FromResource("AfpInit.Images.cart2.png"), Aspect = Aspect.AspectFill };
            _layout.Children.Add(img,
                                new Rectangle(0.90, 0.1, 50, 50),
                                AbsoluteLayoutFlags.PositionProportional);

            _total = new Label();
            _total.Text = Order.OrderTotal.ToString();

            _total.HorizontalOptions = LayoutOptions.FillAndExpand;
            _total.HorizontalTextAlignment = TextAlignment.Center;
            _total.VerticalTextAlignment = TextAlignment.Center;
            _total.VerticalOptions = LayoutOptions.FillAndExpand;
            _total.TextColor = Color.White;
            //_total.BackgroundColor = Color.DarkRed;
            _layout.Children.Add(_total,
                                new Rectangle(0.97, 0.05, 50, 50),
                                AbsoluteLayoutFlags.PositionProportional);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                GoToCart();
            };
            img.GestureRecognizers.Add(tapGestureRecognizer);
        }

        void SetItemName()
        {
            _name = new Label();
            _name.Text = "СУП ФО ГОВЯДИНА";

            _name.HorizontalOptions = LayoutOptions.FillAndExpand;
            _name.HorizontalTextAlignment = TextAlignment.Center;
            _name.VerticalTextAlignment = TextAlignment.Center;
            _name.VerticalOptions = LayoutOptions.FillAndExpand;
            _name.TextColor = Color.Black;
            _layout.Children.Add(_name,
                                new Rectangle(0.5, 0.8, 150, 50),
                                AbsoluteLayoutFlags.PositionProportional);
        }

        void SetItemCount()
        {
            _howMany = new Label();

            _howMany.Text = _soupCounter.ToString();

            _howMany.HorizontalOptions = LayoutOptions.FillAndExpand;
            _howMany.HorizontalTextAlignment = TextAlignment.Center;
            _howMany.VerticalTextAlignment = TextAlignment.Center;
            _howMany.VerticalOptions = LayoutOptions.FillAndExpand;
            _howMany.TextColor = Color.Black;
            _layout.Children.Add(_howMany,
                                new Rectangle(0.5, 0.9, 50, 50),
                                AbsoluteLayoutFlags.PositionProportional);

        }

        void SetAddButton()
        {
            _buttonAdd = new Button();
            _buttonAdd.Text = "+";
            _buttonAdd.BackgroundColor = Color.DarkGreen;
            _buttonAdd.TextColor = Color.White;
            _layout.Children.Add(_buttonAdd,
                                new Rectangle(0.8, 0.9, 0.2, 0.1),
                                AbsoluteLayoutFlags.All);

            _buttonAdd.Clicked += OnButtonAddClicked;
        }

        void SetSubtractButton()
        {
            _buttonSubtract = new Button();
            _buttonSubtract.Text = "-";
            _buttonSubtract.BackgroundColor = Color.DarkRed;
            _buttonSubtract.TextColor = Color.White;
            _layout.Children.Add(_buttonSubtract,
                                new Rectangle(0.2, 0.9, 0.2, 0.1),
                                AbsoluteLayoutFlags.All);

            _buttonSubtract.Clicked += OnButtonSubtractClicked;
        }

        void OnButtonAddClicked(object sender, EventArgs e)
        {
            _soupCounter++;
            ZeroCounter();

            if (_soupCounter > 0)
            {
                Order.OrderTotal += 350;
            }
            InsertText();
        }


        void OnButtonSubtractClicked(object sender, EventArgs e)
        {

            _soupCounter--;
            if (_soupCounter == 0)
            {
                SetCart();
                _layout.Children.Remove(_buttonAdd);
                _layout.Children.Remove(_buttonSubtract);
                _layout.Children.Remove(_howMany);

            }
            if (_soupCounter >= 0)
            {
                Order.OrderTotal -= 350;
            }
            ZeroCounter();

            InsertText();
        }

        void InsertText()
        {
            _total.Text = "";
            _total.Text = Order.OrderTotal.ToString();

            _howMany.Text = "";
            _howMany.Text = _soupCounter.ToString();

            Order.CountFo = _soupCounter;
        }

        public static void TotalCorrect(SoupPage page)
        {
            try
            {
                page._total.Text = "";
                page._total.Text = Order.OrderTotal.ToString();
            }
            catch (Exception e)
            {

            }

        }

        void ZeroCounter()
        {
            if (_soupCounter < 0)
            {
                _soupCounter = 0;
            }
        }
    }
}