using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using XamarinFirebase.Adapter;
using XamarinFirebase.Data_Models;
using XamarinFirebase.EventListeners;
using System.Collections.Generic;

namespace XamarinFirebase
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView myRecyclerView;
        List<MyDataModel> MyDatasList;
        MyDataListeners dataListener;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.myRecyclerView);

            RetriveData();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var trans = SupportFragmentManager.BeginTransaction();
        }

        private void SetupRecyClerView()
        {
            myRecyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView.Context));
            MyDataAdapter adapter = new MyDataAdapter(MyDatasList);
            myRecyclerView.SetAdapter(adapter);
        }

        public void CreateData()
        {
            MyDatasList = new List<MyDataModel>();
        }

        public void RetriveData()
        {
            dataListener = new MyDataListeners();
            dataListener.Create();
            dataListener.MyDataRetrived += DataListener_DataRetrived;
        }

        private void DataListener_DataRetrived(object sender, MyDataListeners.MyDataEventArgs e)
        {
            MyDatasList = e.Data;
            SetupRecyClerView();
        }
    }
}