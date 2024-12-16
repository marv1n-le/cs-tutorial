namespace Anonymous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Anonymous - kieu du lieu vo danh
            //Object - thuoc tinh - chi doc
            //new {thuoctinh = giatri, thuoctrinh2 = giatri2}
            var sanpham = new { Ten = "Iphone", Gia = 1000 };
            //sanpham.Ten = "Samsung"; //khong the thay doi gia tri cua san pham
            Console.WriteLine(sanpham.Ten);
            Console.WriteLine(sanpham.Gia);

            List<SinhVien> sinhVien = new List<SinhVien>
            {
                new SinhVien {Ten = "A", Tuoi = 20},
                new SinhVien {Ten = "B", Tuoi = 21},
                new SinhVien {Ten = "C", Tuoi = 22},
            };

            var ketqua = from sv in sinhVien
                         where sv.Tuoi > 20
                         select new { TenLa = sv.Ten, Tuoi = sv.Tuoi };

            foreach (var sinhvien in ketqua)
            {
                Console.WriteLine(sinhvien.TenLa + " " + sinhvien.Tuoi);
            }

            //Dynamic - kieu du lieu dong 
            static void PrintInfo(dynamic obj)
            {
                Console.WriteLine(obj.Ten);
                Console.WriteLine(obj.Tuoi);
                obj.Hello();
                obj.Xinchao();
                Console.WriteLine(obj.TinhTong(5, 6));
            }

            dynamic svv = new SinhVien { Ten = "A", Tuoi = 20 };
            Console.WriteLine(svv.Ten);


        }
        class SinhVien
        {
            public string Ten { get; set; }
            public int Tuoi { get; set; }
        }
    }
}
