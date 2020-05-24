using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace BethanyPieShopMobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _orderButton;
        private Button _cartButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            FindViews();
            LinkEventHandlers();
        }
        private void FindViews()
        {
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
            _cartButton = FindViewById<Button>(Resource.Id.cartButton);
        }
        private void LinkEventHandlers()
        {
            _orderButton.Click += _orderButton_Click;
            _cartButton.Click += CartButton_Click;
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        private void _orderButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PieMenuActivity));
            StartActivity(intent);
        }

        public void GoogleMapsButton_Click(object sender, EventArgs e)
        {
            var geolocation = Android.Net.Uri.Parse("geo:50.850346,4.351721");
            var intent = new Intent(Intent.ActionView, geolocation);
            StartActivity(intent);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}