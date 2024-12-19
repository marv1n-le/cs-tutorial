using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CS10_DependencyInjection
{

    //Dependency Injection
    //Dependency - 1 lop can 1 lop khac de thuc hien chuc nang - phu thuoc
    //Inverse of Control (IoC)/Dependency inversion - nguoc lai voi thong thuong, thong thuong la lop cha tao lop con, nhung o day lop con tao lop cha

    interface IClassB
    {
        public void ActionB();
    }

    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        IClassC c_dependency;

        public ClassB(IClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }


    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }

    class Horn
    {
        //int level = 0;
        //public Horn(int level)
        //{
        //    this.level = level;
        //}

        public void Beep() => Console.WriteLine("Beep");
    }

    class Car
    {
        public Horn horn { get; set; }

        //Inject bang phuong thuc khoi tao
        public Car(Horn horn)
        {
            this.horn = horn;
        }
        public void Beep()
        {
            horn.Beep();
        }

    }


    public class MyServiceOptions
    {
        public string data1 { get; set; }

        public int data2 { get; set; }


    }

        public class MyService
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
        public MyService(IOptions<MyServiceOptions> options)
        {
            var _options = options.Value;
            data1 = _options.data1;
            data2 = _options.data2;
        }
        public void PrintData()
        {
            Console.WriteLine($"Data1: {data1}, Data2: {data2}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //IClassC objectC = new ClassC1();
            //IClassB objectB = new ClassB1(objectC);
            //ClassA objectA = new ClassA(objectB);

            //objectA.ActionA();
            //Horn horn = new Horn();
            //Car car = new Car(horn);
            //car.horn = horn;
            //car.Beep();
            //Thu vien DI
            //DI Container : ServiceCollection
            // Dang ki cac dich vu(lop) va cac phu thuoc
            //Get Service

            //Dang ki cac dich vu
            //IClassC, ClassC, ClassC1

            //Singleton
            //services.AddScoped<IClassC, ClassC1>();

            //ClassA
            //IClassC, ClassC, ClassC1
            //IClassB, ClassB, ClassB1
            //services.AddSingleton<ClassA, ClassA>();
            //services.AddSingleton<IClassB, ClassB>();
            //services.AddSingleton<IClassC, ClassC>();
            
            //services.Configure<MyServiceOptions>(options =>
            //{
            //    options.data1 = "Hello";
            //    options.data2 = 123;
            //});



            //ClassA a = provider.GetService<ClassA>();
            //a.ActionA();

            //var classc = provider.GetService<IClassC>();

            //for (int i = 0; i < 5; i++)
            //{
            //    IClassC c = provider.GetService<IClassC>();
            //    Console.WriteLine(c.GetHashCode());

            //}

            var configBuilder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
           .AddJsonFile("appsettings.json");                  // nạp config định dạng JSON
            var configurationroot = configBuilder.Build();                // Tạo configurationroot

            var services = new ServiceCollection();

            services.Configure<MyServiceOptions>(configurationroot.GetSection("MyServiceOptions"));

            services.AddSingleton<MyService>();

            var provider = services.BuildServiceProvider();

            var myservice = provider.GetService<MyService>();
            myservice.PrintData();

            //var data = configurationRoot.GetSection("section1").GetSection("key1").Value;
            //var data2 = configurationRoot.GetSection("MyServiceOptions").GetSection("data").Value;

            //Console.WriteLine(data2);
            //Console.WriteLine(data);


        }
    }
}
