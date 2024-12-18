namespace Async_Await
{
    class Program
    {
        static void DoSomeThing(int secs, string msgs, ConsoleColor color)
        {
            lock(Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("Start...");
                Console.ResetColor();
            }

            
                for (int i = 1; i <= secs; i++)
                {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{i} {msgs}");

                    Thread.Sleep(1000);
                    Console.ResetColor();
                }
            }

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("End...");
                Console.ResetColor();
            }
        }

        static async Task Task2()
        {
            Task t2 = new Task(
                (object obj) =>
                {
                    string tentacvu = (string)obj;
                    DoSomeThing(4, tentacvu, ConsoleColor.Green);
                }, "HelloT2");
            t2.Start();
            await t2;
            //t2.Wait();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Task2 completed");

            //return t2;
        }

        static async Task Abc()
        {
            Task task = new Task(() =>
            {
                //Insert your code here
            });
            task.Start();
            await task;
            await File.WriteAllTextAsync("abc.txt", "asdf");  //await for the file to be written (example) 
        }

        static async Task Task1()
        {
            Task t1 = new Task(
                () =>
                {
                    DoSomeThing(4, "HelloT1", ConsoleColor.Red);
                });

            t1.Start();
            await t1;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Task1 completed");
            //return t1;
        }

        static async Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(() =>
            {
                DoSomeThing(2, "HelloT4", ConsoleColor.Yellow);
                return "Task4 completed";
            });
            t4.Start();
            var kq = await t4;
            Console.WriteLine("KetThuc");
            return kq;
        }

        static async Task<string> Task5()
        {
            Task<string> t5 = new Task<string>(
                (object obj) =>
                {
                    string t = (string)obj;
                    DoSomeThing(2, t, ConsoleColor.Magenta);
                    return "Task5 completed";
                }, "HelloT5");
            t5.Start();
            var kq = await t5;
            return kq;
        }

        static async Task<Object> Task()
        {
            Task<Object> task = new Task<object>(() =>
            {
                return new object();
            });
            return task;
        }
        //asynchronous (multi-threading) programming
        static async Task Main(string[] args)
        {
            //Task t1 = Task1();
            //Task t2 = Task2();

            //Task.WaitAll(t1, t2);

            //Task<T> : Task co gia tri tra ve
            //Task<string> t3 = new Task<string>(Func<string>); //() => { return string;}

            Task<string> t4 = Task4();
            Task<string> t5 = Task5();

            //Task<string> t4 = new Task<string>(Func<object, string>, object); //(object ob) => { return string;}


            

            


            //synchronous
            DoSomeThing(2, "HelloT3", ConsoleColor.Yellow);
            //lam viec tung tac vu, task truoc xong moi lam task sau
            var kq4 = await t4; //lay ket qua tra ve cua task
            var kq5 = await t5;

            Console.WriteLine(kq4);
            Console.WriteLine(kq5);
            //await t1;
            //await t2;
            Console.WriteLine("Thread all completed. Press any key to exit the program");
            Console.ReadLine();

        }
    }
}
