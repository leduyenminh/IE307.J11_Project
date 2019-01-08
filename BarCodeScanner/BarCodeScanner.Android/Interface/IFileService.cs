using System;

using System.IO;



namespace BarCodeScanner.Droid.Interface
{
    public interface IFileService
    {
        void SavePicture(String name, Stream data, String location="temp");
    }
}