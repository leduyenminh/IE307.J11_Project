
using System.IO;


using BarCodeScanner.Droid.Interface;
using System.Security.Permissions;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(BarCodeScanner.Droid.FileService))]
namespace BarCodeScanner.Droid
{
    public class FileService : IFileService
    {
       

        public void SavePicture(string name, Stream data, string location = "temp")
        {

            
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
            //Java.IO.File sdCard = Android.OS.Environment.ExternalStorageDirectory;
            //Java.IO.File dir = new Java.IO.File(sdCard.AbsolutePath + "/" + location);
            //dir.Mkdirs();
            var pictures = dir.AbsolutePath;

            //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //documentsPath = Path.Combine(documentsPath, location);
            //Directory.CreateDirectory(documentsPath);
            //string filePath = Path.Combine(documentsPath, name);
            string filePath = Path.Combine(pictures,name);
            System.IO.FileInfo fname = new System.IO.FileInfo(filePath);
            FileIOPermission permit = new FileIOPermission(FileIOPermissionAccess.AllAccess, fname.DirectoryName);
            bool all = true;
            try
            {
                permit.Demand();
                permit.PermitOnly();

            }

            catch (System.Security.SecurityException ex)
            {
                all = false;
            }
            byte[] bArray = new byte[data.Length];
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (data)
                {
                    data.Read(bArray, 0, (int)data.Length);
                }
                int length = bArray.Length;
                fs.Write(bArray, 0, length);

            }

        

        }
    }
}