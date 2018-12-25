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
using SQLite;
using SQLite.Net.Attributes;

namespace BarCodeScanner.Droid.Model
{
    public class SinhVien
    {
        [PrimaryKey,AutoIncrement]
        public int mssv;
        public String hoten;
        public String lop;
        public String barcode;
    }
}