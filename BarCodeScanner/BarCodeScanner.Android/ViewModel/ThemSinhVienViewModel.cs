using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarCodeScanner.Droid.Interface;
using BarCodeScanner.Droid.Model;
using Xamarin.Forms;

namespace BarCodeScanner.Droid.ViewModel
{
    public class ThemSinhVienViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ICommand AddSinhVien { get; private set; }
        public ISinhVienRepository sinhvienRepository;
        
        private ObservableCollection<SinhVien> sinhviens;
        
        private SinhVien sinhvien;
        
        public ThemSinhVienViewModel()
        {
            sinhvienRepository = new SinhVienRepository();
           
            sinhviens = sinhvienRepository.GetSinhViens();
            
            sinhvien = new SinhVien();
            
            AddSinhVien = new Command(InsertSinhVien);
        }
        public ObservableCollection<SinhVien> SinhViens
        {
            get { return sinhviens; }
            set
            {
                sinhviens = value;
                RaisePropertyChanged("SinhViens");
            }

        }
        
        public void InsertSinhVien()
        {
            sinhvienRepository.Insert(sinhvien);
        }
    }
}