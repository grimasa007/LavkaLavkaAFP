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
    public partial class GusBurger : CarouselPage
    {
        

        private int _gusBurgerCounter;
        private AbsoluteLayout _layout;
        private Label _howMany  = new Label();
        private Label _itemName = new Label();
        private Button _buttonSubtract;
        private Button _buttonAdd;
        private Label _total = new Label();
        private Label _name;
        private BikBurgerPage _burgerPage;
        private SoupPage _soupPage;
        private Sandwich _sandPage;

        public GusBurger()
        {
            InitializeComponent();
            CreateLayout();
            CreateContentPages();
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

        void InitMenuItemNameName()
        {
            _itemName.Text = "БЫК БУРГЕР "
                + Environment.NewLine + Environment.NewLine +
                "Кол-во: " + _gusBurgerCounter +
                Environment.NewLine + Environment.NewLine +
                "Цена: 350 р.";

            _itemName.HorizontalOptions = LayoutOptions.FillAndExpand;
            _itemName.VerticalOptions = LayoutOptions.FillAndExpand;
            _itemName.TextColor = Color.White;
            _layout.Children.Add(_itemName,
                                new Rectangle(0, 0, 0.25, 0.7),
                                AbsoluteLayoutFlags.All);
        }

        void CreateLayout()
        {
            _layout = new AbsoluteLayout();           
        }


        void CreateContentPages()
        {
            ContentPage contGusBurger = new ContentPage();
            contGusBurger.Content = _layout;
            Children.Add(contGusBurger);

            _burgerPage = new BikBurgerPage(_soupPage,_sandPage,this);
            _soupPage = new SoupPage(_burgerPage, _sandPage, this);
            _sandPage = new Sandwich(_burgerPage, _soupPage, this);

            Children.Add(_burgerPage);           
            Children.Add(_soupPage);           
            Children.Add(_sandPage);
            
        }


        async void GoToCart()
        {
            await Navigation.PushAsync(new Zakaz(_burgerPage, _soupPage, _sandPage, this));
        }

        protected override void OnCurrentPageChanged()
        {
            // DisplayAlert("В Вашей корзине", "" + "Бик Бургеров", "Ok");
            TotalCorrect();
            BikBurgerPage.TotalCorrect(_burgerPage);
            SoupPage.TotalCorrect(_soupPage);
            Sandwich.TotalCorrect(_sandPage);
        }

        void SetFoodImage()
        {
            var img = new Image { Source = ImageSource.FromResource("AfpInit.Images.burger2.JPG"), Aspect = Aspect.AspectFill };
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
                _gusBurgerCounter++;
                Order.OrderTotal += 350;
                SetItemCount();
                InsertText();
            };
            img.GestureRecognizers.Add(tapGestureRecognizer);

        }

        void SetCheckOut()
        {
            var img = new Image { Source = ImageSource.FromResource("AfpInit.Images.cart2.png"), Aspect = Aspect.AspectFill };
            _layout.Children.Add(img,
                                new Rectangle(0.90, 0.1, 50, 50),
                                AbsoluteLayoutFlags.PositionProportional);

            //_total = new Label();
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
            _name.Text = "ГУСЬ БУРГЕР";

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
            

            _howMany.Text = _gusBurgerCounter.ToString();

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
            _gusBurgerCounter++;

            ZeroCounter();

            if (_gusBurgerCounter > 0)
            {
                Order.OrderTotal += 350;
            }
            InsertText();
        }


        void OnButtonSubtractClicked(object sender, EventArgs e)
        {

            _gusBurgerCounter--;
            if (_gusBurgerCounter == 0)
            {
                SetCart();
                _layout.Children.Remove(_buttonAdd);
                _layout.Children.Remove(_buttonSubtract);
                _layout.Children.Remove(_howMany);

            }
            if (_gusBurgerCounter >= 0)
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
            _howMany.Text = _gusBurgerCounter.ToString();

            Order.CountGus = _gusBurgerCounter;
        }

        void TotalCorrect()
        {
            try
            {
                _total.Text = "";
                _total.Text = Order.OrderTotal.ToString();
            }
            catch (Exception e)
            {
                //DisplayAlert("В Вашей корзине", e.ToString() + "Бик Бургеров", "Ok");
            }

        }

        void ZeroCounter()
        {
            if (_gusBurgerCounter < 0)
            {
                _gusBurgerCounter = 0;
                
            }
        }

        public void OnDataSent(object source, EventArgs e)
        {
            //AllZero();
        }

        public static void AllZero(GusBurger burger)
        {

            if (burger != null)
            {
                burger._total.Text = "";
                burger._howMany.Text = "";
                burger._gusBurgerCounter = 0;
            }

            Order.CountGus = 0;
            Order.OrderTotal = 0;
        }
    }
}