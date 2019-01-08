using System;

using System.IO;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

using ZXing.Mobile;

using Android.Graphics;

using ZXing.QrCode;

using BarCodeScanner.Droid.Interface;

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
                    String value = txt_mssv.Text.Trim() + "_" + txt_hoten.Text.Trim() + "_" + txt_lop.Text.Trim();
                    var stream = GenerateQrImage(value, 300, 300);
                    Stream strm = new MemoryStream(stream);
                    img_barcode.Source = ImageSource.FromStream(() => strm);
                    Stream strm2 = new MemoryStream(stream);
                    string name = "MY_QR_" + txt_mssv.Text.ToString() +"_" +txt_hoten.Text.ToString() + ".jpg";
                    DependencyService.Get<IFileService>().SavePicture(name, strm2, "BarcodeImage");

                }
                else
                {
                    DisplayAlert("Error", "Bạn phải nhập đủ giá trị", "OK");
                }
               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                DisplayAlert("Error", "Đã có lỗi xảy ra!", "OK");
                
            }
            
        }
      
        public byte[] GenerateQrImage(string content, int width, int height)
        {
            var options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width,
                Margin = 0,
                PureBarcode = true
            };

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };
            var stream = new MemoryStream();
            
            // Generate bitmap
            var bitmap = writer.Write(content);
            if (bitmap != null)
            {
                   
                        bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
                 
                        return stream.ToArray();
                 
             }
            return null;
        }

    }
}