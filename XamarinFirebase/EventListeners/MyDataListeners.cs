using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using XamarinFirebase.Data_Models;
using XamarinFirebase.Helpers;

namespace XamarinFirebase.EventListeners
{
    public class MyDataListeners : Java.Lang.Object, IValueEventListener
    {
        List<MyDataModel> dataList = new List<MyDataModel>();

        public event EventHandler<MyDataEventArgs> MyDataRetrived;

        public class MyDataEventArgs : EventArgs
        {
            public List<MyDataModel> Data { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {
           
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
           if(snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                dataList.Clear();
                foreach (DataSnapshot myData in child)
                {
                    MyDataModel datas = new MyDataModel();
                    datas.MyData = myData.Child("Data").Value.ToString();
                    dataList.Add(datas);
                }
                MyDataRetrived.Invoke(this, new MyDataEventArgs { Data = dataList });
            }
        }

        public void Create()
        {
            DatabaseReference mydataRef = AppDataHelper.GetDatabase().GetReference("");
            mydataRef.AddValueEventListener(this);
        }
    }
}