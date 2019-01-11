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
using BarCodeScanner.Droid.Interface;
using BarCodeScanner.Droid.Model;
using BarCodeScanner.Models;

namespace BarCodeScanner.Droid
{
    public class SinhVienRepository:ISinhVienRepository
    {
        Database db;
        public SinhVienRepository()
        {
            db = new Database();
        }
        public bool Delete(SinhVien sv)
        {
            return db.DeleteSinhVien(sv);
        }
        public SinhVien GetSinhVienById(string Mssv)
        {
            return db.GetSinhVienById(Mssv);
        }
        public ObservableCollection<SinhVien> GetSinhViens()
        {
            
            return new ObservableCollection<SinhVien>(db.GetSinhViens());
        }
        public bool Insert(SinhVien sv)
        {
            if (sv.Mssv != "" && sv.Tensv != "" && sv.Lop != "")
            {
                
                return db.InsertSinhVien(sv);
            }
            else
            {
                
                return false;
            }
        }
        public bool Update(SinhVien sv)
        {
            return db.UpdateSinhVien(sv);
        }

    }
}