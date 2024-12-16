namespace Inheritance
{
     class Animal
    {
        public Animal()
        {
            Console.WriteLine("Animal constructor");
        }

        public Animal(string ab)
        {
            Console.WriteLine("Animal constructor(2) " + ab);
        }
        public int Legs { get; set; }
        public float Weight { get; set; }
        public void ShowLegs()
        {
            Console.WriteLine("Legs: " + Legs);
        }
    }

    //sealed: niem phong lop, khong cho ke thua

    class Cat : Animal
    {
        public string Food;

        public Cat(string s) : base(s) //muon goi phuong thuc cua lop cha thi phai co tu khoa base, neu khong co thi mac dinh goi phuong thuc khong tham so
        {
            this.Legs = 4;
            this.Food = "Fish";
            Console.WriteLine("Cat constructor");
        }
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
        public new void ShowLegs()
        {
            Console.WriteLine("Cat's legs: " + Legs);
        }
        public void ShowInfo()
        {
            base.ShowLegs(); // goi phuong thuc cua lop cha
            ShowLegs();
        }
    }

    class A { }
    class B : A { }
    class C : B { }
    // a co the new B, nhung b khong the new A -> con khong the new cha chi co the cha new duoc con hoac chinh no



    public class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("toi la con meo");
            A a = new B();
            B b = new C();
            //C c = new A(): 
        }
    }
}
