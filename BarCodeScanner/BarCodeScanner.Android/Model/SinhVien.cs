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

namespace BarCodeScanner.Droid.Model
{
    public class SinhVien
    {
        [PrimaryKey, AutoIncrement]
        public string Mssv { get; set; }
        public string Tensv { get; set; }
        public string Lop { get; set; }
        public string Barcodevalue { get; set; }
        public SinhVien() { }
        public SinhVien(string mssv, string tensv, string lop)
        {
            Mssv = mssv;
            Tensv = tensv;
            Lop = lop;
            Barcodevalue = mssv + "_" + tensv + "_" + lop;
        }
    }
}