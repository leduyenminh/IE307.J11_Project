using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.Net.Mobile;
using ZXing.Net;
using BarCodeScanner.Droid.Views;

namespace BarCodeScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MH_TraCuuSinhVien : ContentPage
    {
        ZXingScannerPage scanPage;
        public MH_TraCuuSinhVien()
        {
            InitializeComponent();
            btnScanDefault.Clicked += btnScanDefault_ClickedAsync;
        }
        // Add btnScanDefault click event
        private async void btnScanDefault_ClickedAsync(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                // Do ... with result
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopModalAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };
            await Navigation.PushModalAsync(scanPage);
        }

        private void btn_TraCuuTheoMSSV_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MH_TraCuuTheoMSSV());
        }

        //private async void ZXingScannerView_OnOnScanResult(Result result)
        //{

        //    // Stop analysis until we navigate away so we don't keep reading barcodes
        //    //zxing.IsAnalyzing = false;

        //    // Show an alert
        //    //await DisplayAlert("Scanned Barcode", result.Text, "OK");



        //    // Navigate away
        //   // await Navigation.PopAsync();
        //}

        //private void Overlay_OnFlashButtonClicked(Button sender, EventArgs e)
        //{
        //    //zxing.IsTorchOn = !zxing.IsTorchOn;

        //}
        protected override void OnAppearing()
        {
            //base.OnAppearing();

            //zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            //zxing.IsScanning = false;

            //base.OnDisappearing();
        }

    }
}