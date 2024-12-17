using System.ComponentModel;

namespace Delegate
{
    public delegate void ShowLog(string message);
    public class Program
    {
        //delegate (Type safe function pointer) bien = phuong thuc
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            ShowLog log = null;
            log = Info;
            log?.Invoke("Hello World");
            log = Warning;
            log?.Invoke("Warning!!!");

            //delegate co the tro den nhieu phuong thuc

            log += Info;
            log += Warning;
            log?.Invoke("Hello World");

            //Action, Func : delegate co san
            //Thay vi khai bao delegate ShowLog, ta co the dung Action<string> hoac Func<string, int> hoac Func<int, int, string>...
            Action action; // ~ delegate void Kieu();
            Action<string, int> action1; // ~ delegate void Kieu(string s, int i);
            Action<string> action2;

            action2 = Warning;
            action2?.Invoke("Hello World");

            Func<int> f1; // ~ delegate int Kieu();
            Func<int, double, string> f2; // ~ delegate string Kieu(int i, double d); kieu tra ve phai la kieu cuoi cung

            Func<int, double, ShowLog> f3;

        }
    }
}
