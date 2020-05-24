using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BethanyPieShopMobile.Adapters;

namespace BethanyPieShopMobile
{
    [Activity(Label = "PieMenuActivity")]
    public class PieMenuActivity : Activity
    {
        private RecyclerView _pieRecyclerView;
        private RecyclerView.LayoutManager _pieLayoutManager;
        private PieAdapter _pieAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.pie_menu);
            _pieRecyclerView = FindViewById<RecyclerView>(Resource.Id.pieMenuRecyclerView);
            
            _pieLayoutManager = new LinearLayoutManager(this);            
            _pieRecyclerView.SetLayoutManager(_pieLayoutManager);
            _pieAdapter = new PieAdapter();
            _pieRecyclerView.SetAdapter(_pieAdapter);

            _pieAdapter.ItemClick += _pieAdapter_ItemClick;
            
        }

        private void _pieAdapter_ItemClick(object sender, int e)
        {
            var intent = new Intent(this, typeof(PieDetailActivity));
            intent.PutExtra("selectedPieId", e);
            StartActivity(intent);
        }
    }
}