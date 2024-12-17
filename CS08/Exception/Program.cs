using System.Security.Cryptography.X509Certificates;

namespace Exception_
{
    public class NameEmptyException : Exception
    {
        public NameEmptyException() : base("Ten phai khac rong")
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 2;

            //var c = a / b;
            try
            {
                var c = a / b;
                int[] arr = {1 , 2};
                var x = arr[7];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.GetType().Name);
            }


            static void Register(string name, string age)
            {
                Console.WriteLine("Registering...");
                if(string.IsNullOrEmpty(name))
                {
                    Exception ex = new Exception("Name is required");
                    throw new NameEmptyException();
                }
            }

            try
            {
                Register("", "20");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
