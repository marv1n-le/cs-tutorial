namespace Event
{
    class Program
    {
        //public delegate void SuKienNhapSo(int n);
        public event EventHandler suKienNhapSo;

        //publisher -> class that sends the event
        //subscriber -> class that receives the event

        //publisher
        class DuLieuNhap: EventArgs
        {
            public int So;
            public DuLieuNhap(int x) => So = x;

        }

        class  UserInput
        {
            // ~ delegate void Kieu(object? sender, EventArgs args); truyen vao 2 tham so, object va EventArgs
            public event EventHandler suKienNhapSo;
            
            public void Input()
            {
                do
                {
                    Console.WriteLine("Nhap so: ");
                    string s = Console.ReadLine();
                    int i = Int32.Parse(s);
                    //phat su kien
                    suKienNhapSo?.Invoke(null, new DuLieuNhap(i));
                }
                while (true);
            }
        }

        class TinhCan
        {
            public void Can(object? sender, EventArgs e)
            {
                DuLieuNhap duLieuNhap = (DuLieuNhap)e;
                int n = duLieuNhap.So;
                Console.WriteLine("Can bac 2 cua {0} la {1}", n, Math.Sqrt(n));
            }

            public void Sub(UserInput userInput)
            {
                userInput.suKienNhapSo += Can;
            }
        }

        class TinhBinhPhuong
        {
            public void BinhPhuong(object sender, EventArgs e)
            {
                DuLieuNhap duLieuNhap = (DuLieuNhap)e;
                int n = duLieuNhap.So;
                Console.WriteLine("Binh phuong cua {0} la {1}", n, n * n);
            }

            public void Sub(UserInput userInput)
            {
                userInput.suKienNhapSo += BinhPhuong;
            }
        }

        static void Main(string[] args)
        {
            //publisher
            UserInput userInput = new UserInput();
            userInput.suKienNhapSo += (sender, e) =>
            {
                DuLieuNhap duLieuNhap = (DuLieuNhap)e;
                int x = duLieuNhap.So;
                Console.WriteLine("So vua nhap la: {0}", x);
            };

            //subscriber
            TinhCan tinhCan = new TinhCan();

            TinhBinhPhuong tinhBinhPhuong = new TinhBinhPhuong();
            tinhBinhPhuong.Sub(userInput);
            tinhCan.Sub(userInput);

            userInput.Input();


        }
    }
}
