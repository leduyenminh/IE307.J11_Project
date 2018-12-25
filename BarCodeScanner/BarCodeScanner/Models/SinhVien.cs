using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite; 


namespace BarCodeScanner.Models
{
    class SinhVien
    {
        public int mssv { get; set; }
        public String tensv { get; set; }
        public String quequan { get; set; }
        public String tenkhoa;
       

    }
    class CodeSinhVien 
    {
        public int macode { get; set; }
        public String code { get; set; }
        public int mssv { get; set; }

    }

}
