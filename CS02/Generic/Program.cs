namespace Generic
{
    public class Program
    {
        //static void Swap<T>(ref T x,ref T y)
        //{
        //    T temp = x;
        //    x = y;
        //    y = temp;
        //}

        class Product<A>
        {
            A Id;
            
            public void SetId(A id)
            {
                this.Id = id;
            }

            public void PrintInf()
            {
                Console.WriteLine("Id: " + this.Id);
            }
        }
        static void Main(string[] args)
        {
            //int a = 5;  
            //int b = 45;
            //Console.WriteLine("a: " + a + " b: " + b);
            //Swap<int>(ref a,ref b); //phai cho generic type
            //Console.WriteLine("a: " + a + " b: " + b);

            Product<int> product = new Product<int>();
            product.SetId(5);
            product.PrintInf();

            Product<string> product2 = new Product<string>();
            product2.SetId("Hello");
            product2.PrintInf();
        }
    }
}
