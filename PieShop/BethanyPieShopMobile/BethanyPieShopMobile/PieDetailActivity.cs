

using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BethanyPieShopMobile.Core.Model;
using BethanyPieShopMobile.Core.Repository;
using BethanyPieShopMobile.Utility;

namespace BethanyPieShopMobile
{
    [Activity(Label = "PieDetailActivity"/*, MainLauncher =true*/)]
    public class PieDetailActivity : Activity
    {
        private PieRepository _pieRepository;
        private Pie _selectedPie;
        private ImageView _pieImageView;
        private TextView _pieNameTextView;
        private TextView _descriptionTextView;
        private TextView _shortDescriptionTextView;
        private TextView _priceTextView;
        private EditText _amountEditText;
        private Button _addToCartButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.pie_detail);
            _pieRepository = new PieRepository();
            var selectedPieId = Intent.Extras.GetInt("selectedPieId");
            _selectedPie = _pieRepository.GetPieById(selectedPieId);
            FindViews();
            BindData();
            LinkEventHandler();
        }

        private void LinkEventHandler()
        {
            _addToCartButton.Click += AddToCartButton_Click;
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            var amount = int.Parse(_amountEditText.Text);
            ShoppingCartRepository cartRepository = new ShoppingCartRepository();
            cartRepository.AddToShoppingCart(_selectedPie, amount);
            Toast.MakeText(Application.Context, "Pie added to cart", ToastLength.Long).Show();
            this.Finish();
        }

        private void BindData()
        {
            _pieNameTextView.Text = _selectedPie.Name;
            _shortDescriptionTextView.Text = _selectedPie.ShortDescription;
            _descriptionTextView.Text = _selectedPie.LongDescription;
            _priceTextView.Text = "Price:" + _selectedPie.Price;
            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(_selectedPie.ImageUrl);
            _pieImageView.SetImageBitmap(imageBitmap);
        }

        private void FindViews()
        {
            _pieImageView = FindViewById<ImageView>(Resource.Id.pieImageView);
            _pieNameTextView = FindViewById<TextView>(Resource.Id.pieNameTextView);
            _descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            _shortDescriptionTextView= FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            _priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            _amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            _addToCartButton = FindViewById<Button>(Resource.Id.addToCartButton);
        }
    }
}