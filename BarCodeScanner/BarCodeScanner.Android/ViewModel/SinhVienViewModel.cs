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
using static Android.Provider.Contacts.Intents;

namespace BarCodeScanner.Droid.ViewModel
{
    public class SinhVienViewModel: INotifyPropertyChanged
    {
        private SinhVien sinhvien;
        public ISinhVienRepository sinhvienRepository;
        public ICommand AddSinhVien { get; private set; }
        public ICommand UpdateSinhVien { get; private set; }
        public ICommand DeleteSinhVien { get; private set; }
        public SinhVienViewModel()
        {
            sinhvienRepository = new SinhVienRepository();
            LoadSinhVien();
            AddSinhVien = new Command(Insert);
            UpdateSinhVien = new Command(Update, CanExe);
            DeleteSinhVien = new Command(Delete, CanExe);
            sinhvien = new SinhVien();
        }
        private void Delete()
        {
            sinhvienRepository.Delete(sinhvien);
            LoadSinhVien(); 
        }
        private bool CanExe()
        {
            if (sinhvien == null || sinhvien.Mssv == "")
                return false;
            else return true;
        }
        private void Update()
        {
            sinhvienRepository.Update(sinhvien);
            LoadSinhVien(); 
        }
        public SinhVien SinhVien
        {
            get { return sinhvien; }
            set { sinhvien = value;
                  RaisePropertyChanged("SinhVien");
                ((Command)UpdateSinhVien).ChangeCanExecute();   }
        }
        private void Insert()
        {
            sinhvienRepository.Insert(sinhvien);
            LoadSinhVien();
        }
        public string Mssv
        {
            get { return sinhvien.Mssv; }
            set
            {
                sinhvien.Mssv = value;
                RaisePropertyChanged("Mssv");
            }
        }
        public string Tensv
        {
            get { return sinhvien.Tensv;  }
            set
            {
                sinhvien.Tensv = value;
                RaisePropertyChanged("Tensv");
            }
        }
        public string Lop
        {
            get { return sinhvien.Lop; }
            set
            {
                sinhvien.Lop = value; ;
                RaisePropertyChanged("Lop");
            }
        }
        public string Barcodevalue
        {
            get { return sinhvien.Barcodevalue; }
            set
            {
                sinhvien.Barcodevalue = value; ;
                RaisePropertyChanged("Barcodevalue");
            }
        }
        ObservableCollection<SinhVien> sinhvienlist;
        public ObservableCollection<SinhVien> Sinhvienlist
        {
            get { return sinhvienlist; }
            set
            {
                sinhvienlist = value;
                RaisePropertyChanged("Sinhvienlist");
            }
            
        }
        void LoadSinhVien()
        {
            Sinhvienlist = sinhvienRepository.GetSinhViens();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged   (string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}