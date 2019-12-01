using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTnhom
{
    class Program
    {
        static void Main(string[] args)
        {
            PhanSo phanSo1 = new PhanSo(1, 2);
            PhanSo phanSo2 = new PhanSo(1, 3);
          
            Console.WriteLine(phanSo1.LuyThua(phanSo1, phanSo2,2));
            Console.WriteLine((int)Math.Sqrt(3));
            // Console.WriteLine(phanSo1.Cong(phanSo1, phanSo2));
            //Console.WriteLine(phanSo1.Tru(phanSo1, phanSo2));

            /*
            Console.WriteLine("Nhap phan so 1");
            int TuSo1 = int.Parse(Console.ReadLine());
            int MauSo1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap phan so 2");
            int TuSo2 = int.Parse(Console.ReadLine());
            int MauSo2 = int.Parse(Console.ReadLine());
            PhanSo ps = new PhanSo();

            Console.WriteLine(ps.LuyThua(TuSo1, MauSo1, TuSo2, MauSo2,2));
            */
            Console.ReadKey();
        }
    }
}
