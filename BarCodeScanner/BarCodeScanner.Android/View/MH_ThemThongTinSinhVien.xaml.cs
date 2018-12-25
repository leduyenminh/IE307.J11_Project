using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.Net.Mobile;
using ZXing.Mobile;
using ZXing.Rendering;
using Android.Graphics;
using Android.Content;
using Android.Provider;


namespace BarCodeScanner
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MH_ThemThongTinSinhVien : ContentPage
    {
       
        public MH_ThemThongTinSinhVien()
        {
            InitializeComponent();
            
        }

        
        public void btn_taobarcode_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txt_mssv.Text != "" && txt_hoten.Text != "" && txt_lop.Text != "")
                {
                    var barcode = new ZXingBarcodeImageView
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                    };
                    barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
                    barcode.BarcodeOptions.Width = 500;
                    barcode.BarcodeOptions.Height = 500;
                    barcode.BarcodeValue = txt_mssv.Text.Trim() + "_" + txt_hoten.Text.Trim() + "_" + txt_lop.Text.Trim();
                    // Hiện barcode đã tạo 
                    //img_barcode = barcode;
                    //Content = barcode;
                    SaveQRAsImage(barcode.BarcodeValue);
                    lbl_MaBarcode.Text = barcode.BarcodeValue;
                }
                else
                {
                    DisplayAlert("Error", "cảnh báo", "OK");
                }
               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                DisplayAlert("Error", "Bạn phải nhập giá trị", "OK");
            }
            
        }
        TaskCompletionSource<string> SaveQRComplete = null;
        public async Task SaveQRAsImage(string text)
        {
            SaveQRComplete = new TaskCompletionSource<string>();
            
            try
            {
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 100,
                        Height = 100,
                        Margin = 10
                    }
                };
                barcodeWriter.Renderer = new BitmapRenderer();
                var bitmap = barcodeWriter.Write(text);
                var stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
                stream.Position = 0;

                byte[] imageData = stream.ToArray();
                
                var dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
                //var pictures = dir.AbsolutePath;
                //var DocumentsPath = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryPictures);
                //định dạng tên file ảnh theo ngày tháng để k0 lưu đè ảnh cũ
                string name = "MY_QR" + DateTime.Now.ToString("ddMMyyyyHHmmssfff") + ".jpg";

                string filePath = System.IO.Path.Combine(dir, name);
                File.WriteAllBytes(filePath, imageData);
                //mediascan thêm ảnh vào gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);

                
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(filePath)));
                //dùng Android.App.Application.Context thay cho Xamarin.Forms.Forms.Context
                Android.App.Application.Context.SendBroadcast(mediaScanIntent);
                SaveQRComplete.SetResult(filePath);
                await SaveQRComplete.Task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //await null;
            }

        }

        
    }
}