using CS11_EF.Model;
using Microsoft.EntityFrameworkCore;

namespace CS11_EF
{
    public class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ShopDbContext();
            string databasename = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureCreated();
            if (kq)
            {
                Console.WriteLine($"Create database {databasename} sucessfully!!!");
            }
            else
            {
                Console.WriteLine($"Database {databasename} already had in database");
            }
        }

        static void DropDatabase()
        {
            using var dbcontext = new ShopDbContext();
            string dbName = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureDeleted();
            if (kq)
            {
                Console.WriteLine($"Delete {dbName} sucessfully");
            }
            else
            {
                Console.WriteLine($"Cannot delete database {dbName}");
            }
        }
        static void InsertData()
        {
            using var dbcontext = new ShopDbContext();
            Category c1 = new Category { Name = "Dien thoai", Description = "Dien thoai di dong" };
            Category c2 = new Category() { Name = "Laptop", Description = "Laptop dep lam" };
            dbcontext.Categories.AddRange(c1, c2);
            //var c1 = (from c in dbcontext.Categories where c.CategoryId == 1 select c.CategoryId).FirstOrDefault();
            //var c2 = (from c in dbcontext.Categories where c.CategoryId == 2 select c.CategoryId).FirstOrDefault();
            dbcontext.Products.AddRange(
                new Product { Name = "Iphone 12", Price = 1000, CateId = 1 },
                new Product { Name = "Iphone 11", Price = 900, CateId = 1 },
                new Product { Name = "Dell XPS 13", Price = 2000, CateId = 2 },
                new Product { Name = "Dell XPS 15", Price = 3000, CateId = 2 },
                new Product { Name = "Iphone 12", Price = 1000, Category = c1 });
            dbcontext.SaveChanges();
            if (dbcontext.Products.Count() == 0)
            {
                Console.WriteLine("Insert data fail");
            }
            else Console.WriteLine("Insert data success");
        }
        static void Main(string[] args)
        {
            DropDatabase();
            CreateDatabase();

            InsertData();
            using var dbcontext = new ShopDbContext();
            var product = (from p in dbcontext.Products where p.ProductId == 3 select p)
                .FirstOrDefault();
            //Entry: trả về một đối tượng EntityEntry mà cung cấp thông tin về trạng thái và thực thể được theo dõi
            var e = dbcontext.Entry(product);
            //Reference: trả về một thực thể tham chiếu đến thực thể được theo dõi 
            //Load: tải thực thể từ cơ sở dữ liệu
            e.Reference(p => p.Category).Load();
            if (product.Category != null)
            {
                Console.WriteLine(product.Category.Name + "-" + product.Category.Description);
            }
            else Console.WriteLine("Category null");
            product.PrintInfo();

            var category = (from c in dbcontext.Categories where c.CategoryId == 1 select c).FirstOrDefault();
            Console.WriteLine(category.Name + "-" + category.Description);

            //var e = dbcontext.Entry(category);
            ////Collection: trả về một thực thể tham chiếu đến thực thể được theo dõi 
            //e.Collection(c => c.Products).Load();

            //co lazyload nen khong can load
            if (category.Products != null)
            {
                Console.WriteLine("So san pham: " + category.Products.Count);
                category.Products.ForEach(p => p.PrintInfo());
            }
            else Console.WriteLine("Category null");

        }
    }
}
