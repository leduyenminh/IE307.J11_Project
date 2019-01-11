using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCodeScanner.Droid.Model;

namespace BarCodeScanner.Droid.Interface
{
    public interface ISinhVienRepository
    {
        ObservableCollection<SinhVien> GetSinhViens();
        SinhVien GetSinhVienById(string Mssv);
        bool Insert(SinhVien sv);
        bool Update(SinhVien sv);
        bool Delete(SinhVien sv);

    }
}