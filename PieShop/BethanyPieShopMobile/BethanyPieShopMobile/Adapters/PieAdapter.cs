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
using BethanyPieShopMobile.Core.Model;
using BethanyPieShopMobile.Core.Repository;
using BethanyPieShopMobile.Utility;
using BethanyPieShopMobile.ViewHolders;

namespace BethanyPieShopMobile.Adapters
{
    public class PieAdapter : RecyclerView.Adapter
    {
        public List<Pie> _pies;
        public event EventHandler<int> ItemClick;
        public PieAdapter()
        {
            var pieRepository = new PieRepository();
            _pies = pieRepository.GetAllPies();
        }
        public override int ItemCount => _pies.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is PieViewHolder pieViewHolder)
            {
                pieViewHolder.PieTextView.Text = _pies[position].Name;
                var imageBitMap = ImageHelper.GetImageBitmapFromUrl(_pies[position].ImageThumbnailUrl);
                pieViewHolder.PieImageView.SetImageBitmap(imageBitMap);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.pie_viewholder,parent,false);
            PieViewHolder pieViewHolder = new PieViewHolder(itemView, OnItemClick);
            return pieViewHolder;
        }
         void OnItemClick(int position)
        {
            var pieId = _pies[position].PieId;
            ItemClick?.Invoke(this, pieId);
            
        }
    }
}