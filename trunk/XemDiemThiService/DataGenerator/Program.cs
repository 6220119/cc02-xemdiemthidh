using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DataGenerator
{
    class Program
    {
        static Random rand = new Random();
        static DiemThiDHEntities db = new DiemThiDHEntities();

        static void Main(string[] args)
        {
            Console.WriteLine("Generating ...");
            //GenerateNganh(10);
            //GenerateThiSinh(50);
            Console.WriteLine("Done !");
        }

        static void GenerateThiSinh(int n)
        {
            bool[] gioiTinh = {false, true};

            foreach (Nganh nganh in db.Nganhs)
            {
                string maTruong = nganh.Truong.MaTruong;
                int idNganh = nganh.Id;
                int max = nganh.ThiSinhs.Count();

                for (int i = 0; i < n; ++i)
                {
                    ThiSinh ts = new ThiSinh();
                    ts.Diem1 = 1 + rand.Next() % 10;
                    ts.Diem2 = 1 + rand.Next() % 9;
                    ts.Diem3 = 1 + rand.Next() % 9;
                    ts.HoTen = GenerateString(12);
                    ts.GioiTinh = gioiTinh[(rand.Next() % 2) & 1];
                    ts.IdNganh = idNganh;
                    string date = (1 + rand.Next() % 12).ToString() + "/" +
                        (1 + rand.Next() % 28).ToString() + "/" +
                        (1988 + rand.Next() % 2).ToString();
                    ts.NgaySinh = DateTime.Parse(date);
                    ts.QueQuan = GenerateString(7);
                    ts.SoBaoDanh = maTruong + String.Format("{0:00000}", ++max);

                    db.AddToThiSinhs(ts);
                }
            }
            db.SaveChanges();
        }

        static void GenerateNganh(int n)
        {
            foreach (Truong truong in db.Truongs)
            {
                string maTruong = truong.MaTruong;

                for (int i = 0; i < n; ++i)
                {
                    Nganh nganh = new Nganh();
                    nganh.MaTruong = maTruong;
                    nganh.TenNganh = GenerateString(7).Trim();
                    db.AddToNganhs(nganh);
                }
            }
            db.SaveChanges();
        }

        static string GenerateString(int length)
        {
            string str = Convert.ToChar(65 + rand.Next() % 26).ToString();
            for(int i = 0; i<length - 1; ++i)
            {
                if (rand.Next() % 100 > 40 || str[i] == ' ')
                {
                    char c = Convert.ToChar(97 + rand.Next() % 26);
                    
                    if(str[i] == ' ')
                        c = Char.ToUpper(c);

                    str += c;
                }
                else
                    str += " ";
            }

            return str;
        }
    }
}
