using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarCodeScanner.Droid.Model;
using SQLite;


namespace BarCodeScanner.Models
{

    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public Database()
        {
            try
            {
                //tạo csdl
                using (var connection = new 
                    SQLiteConnection(System.IO.Path.Combine(folder, "qlsv.db")))
                {
                    //tạo bảng
                    connection.CreateTable<SinhVien>();
                    
                }
            }
            catch(SQLiteException ex)
            {
               
            }
        }
        public List<SinhVien> GetSinhViens()
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlsv.db")))
                {
                    
                    return connection.Table<SinhVien>().ToList();
                }
            }
            catch (SQLiteException ex)
            {   
                return null;
            }
        } 
        public SinhVien GetSinhVienById(string Mssv)
        {
            try
            {
                using (var connection = new SQLiteConnection
                     (System.IO.Path.Combine(folder, "qlsv.db")))
                {
                    var dssv = from svs in connection.Table<SinhVien>().ToList()
                               where svs.Mssv == Mssv
                               select svs;
                    return dssv.ToList<SinhVien>().FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public bool InsertSinhVien(SinhVien sv)
        {
            try
            {
                using (var connection = new SQLiteConnection
                     (System.IO.Path.Combine(folder, "qlsv.db")))
                {
                    connection.Insert(sv);
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                return false;
            }
        }
        public bool UpdateSinhVien(SinhVien sv)
        {
            try
            {
                using (var connection = new SQLiteConnection
                     (System.IO.Path.Combine(folder, "qlsv.db")))
                {
                    connection.Update(sv);
                    return true;

                }
            }
            catch(SQLiteException ex)
            {
                return false;
            }
        }
        public bool DeleteSinhVien(SinhVien sv)
        {
            try
            {
                using (var connection = new SQLiteConnection
                     (System.IO.Path.Combine(folder, "qlsv.db")))
                {
                    connection.Delete(sv);
                    return true;
                }
                   
            }
            catch (SQLiteException ex)
            {
                return false; 
            }
        }
    }
}
