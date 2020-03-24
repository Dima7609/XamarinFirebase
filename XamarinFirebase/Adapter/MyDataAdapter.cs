using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using XamarinFirebase.Data_Models;
using Android.Graphics;

namespace XamarinFirebase.Adapter
{
    class MyDataAdapter : RecyclerView.Adapter
    {
        public event EventHandler<MyDataAdapterClickEventArgs> ItemClick;
        public event EventHandler<MyDataAdapterClickEventArgs> ItemLongClick;
        List<MyDataModel> Items;

        public MyDataAdapter(List<MyDataModel>Data)
        {
            Items = Data;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.mydatarow, parent, false);
           
            var vh = new MyDataAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as MyDataAdapterViewHolder;
            holder.nameText.Text = Items[position].MyData;
        }

        public override int ItemCount => Items.Count;

        void OnClick(MyDataAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(MyDataAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class MyDataAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView nameText { get; set; }

        public MyDataAdapterViewHolder(View itemView, Action<MyDataAdapterClickEventArgs> clickListener, Action<MyDataAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            nameText = (TextView)itemView.FindViewById(Resource.Id.nameText);

            itemView.Click += (sender, e) => clickListener(new MyDataAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new MyDataAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class MyDataAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}