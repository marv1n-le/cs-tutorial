using CS11_EF.Model;
using Microsoft.EntityFrameworkCore;

namespace CS11_EF
{
    public class Program
    {
        static void CreateDatabase()
        {
            //using (var dbcontext = new ShopDbContext())
            //{
            //    String databasename = dbcontext.Database.GetDbConnection().Database;// mydata

            //    Console.WriteLine("Tạo " + databasename);

            //    bool result = await dbcontext.Database.EnsureCreatedAsync();
            //    string resultstring = result ? "tạo  thành  công" : "đã có trước đó";
            //    Console.WriteLine($"CSDL {databasename} : {resultstring}");
            //}
            using var dbcontext = new ShopDbContext();
            string databasename = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureCreated();
            if (kq)
            {
                Console.WriteLine($"Tạo {databasename} thành công");
            }
            else
            {
                Console.WriteLine($"{databasename} đã có trước đó");
            }
        }

        static void DeleteDatabase()
        {

            //using (var context = new ShopDbContext())
            //{
            //    String databasename = context.Database.GetDbConnection().Database;
            //    Console.Write($"Có chắc chắn xóa {databasename} (y) ? ");
            //    string input = Console.ReadLine();

            //    // Hỏi lại cho chắc
            //    if (input.ToLower() == "y")
            //    {
            //        bool deleted = await context.Database.EnsureDeletedAsync();
            //        string deletionInfo = deleted ? "đã xóa" : "không xóa được";
            //        Console.WriteLine($"{databasename} {deletionInfo}");
            //    }
            //}
            using var dbcontext = new ShopDbContext();
            string dbName = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureDeleted();
            if (kq )
            {
                Console.WriteLine($"Xóa {dbName} thành công");
            }
            else
            {
                Console.WriteLine($"Không xóa được {dbName}");
            }
        }
        static void Main(string[] args)
        {
            DeleteDatabase();
            CreateDatabase();
        }
    }
}
