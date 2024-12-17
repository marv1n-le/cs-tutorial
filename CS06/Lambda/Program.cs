using System.Reflection.Metadata.Ecma335;

namespace Lambda
{
    public class Program
    {
        /*
        Lambda cung duoc coi nhu la mot ham, nhung no khong co ten, no duoc su dung de truyen vao cac ham khac - Anonymous Function
        Lambda co the co hoac khong co tham so, co the co hoac khong co kieu tra ve
        Lambda co the co hoac khong co thanh phan truy cap, co the co hoac khong co thanh phan tham chieu
        1: (int a, int b) => bieu_thuc;
           (tham so) => bieu_thuc;
        2: (tham_so) =>  
              {
                bieu_thuc;
                return bieu_thuc;
              }



        */
        static void Main(string[] args)
        {
            Action<int, int> action; //khong co kieu tra ve
            action = (a, b) => Console.WriteLine(a + b);

            Action<string> action2;
            action2 = (s) => Console.WriteLine(s);
            Console.WriteLine("Hello");

            Action action3;
            action3 = () => Console.WriteLine("Hello");
            action3?.Invoke();

            //action = null;
            //action = (x, y) =>
            //{
            //    Console.WriteLine(x + y);
            //    action?.Invoke(10, 20);
            //};

            action(1, 2);

            Func<int, int, int> tinhtoan; //co kieu tra ve

            tinhtoan = (a, b) =>
            {
                int kq;
                kq = a + b;
                return kq;
            };

            tinhtoan?.Invoke(10, 20);


            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var result = arr.Select(
                (int x) =>
                {
                    return x * x;
                });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
