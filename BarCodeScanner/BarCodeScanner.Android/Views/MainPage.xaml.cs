using BarCodeScanner.Droid.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace BarCodeScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        //private async void ScanCustomPage(object sender, EventArgs e)
        //{
            
        //    //await Navigation.PushAsync(new ScannerPage());
        //}

        //private async void GenerateBarcode(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new QrCodePage());
        //}
        private void btn_DanhSachSinhVien_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new MH_DanhSachSinhVien());
        }

        private void btn_ThemSinhVien_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MH_ThemThongTinSinhVien());
        }

        private void btn_TraCuuSinhVien_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MH_TraCuuSinhVien());
        }
    }
}
