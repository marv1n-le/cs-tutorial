using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS11_EF.Model
{
    public class ShopDbContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });


        // Thuộc tính products kiểu DbSet<Product> cho biết CSDL có bảng mà
        // thông tin về bảng dữ liệu biểu diễn bởi model Product
        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Categories { set; get; }

        // Chuỗi kết nối tới CSDL (MS SQL Server)
        private const string connectionString = @"
                Data Source=localhost;
                Initial Catalog=ShopDB;
                User ID=sa;Password=12345";

        // Phương thức OnConfiguring gọi mỗi khi một đối tượng DbContext được tạo
        // Nạp chồng nó để thiết lập các cấu hình, như thiết lập chuỗi kết nối
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString);        // thiết lập làm việc với SqlServer
            optionsBuilder.UseLoggerFactory(loggerFactory);  // thiết lập logging
                                                             //optionsBuilder.UseLazyLoadingProxies();           // thiết lập lazy loading, tu dong load du lieu
            Console.WriteLine("OnConfiguring");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Console.WriteLine("OnModelCreating");
            //Fluent API
            //var entity = modelBuilder.Entity(typeof(Product)); //cách 1
            //var entity = modelBuilder.Entity<Product>();  //cách 2
            //Cách 3
            //maping table voi table Product
            modelBuilder.Entity<Product>(
                entity =>
                {
                    //Table mapping
                    entity.ToTable("SanPham"); // tên bảng trong CSDL
                    //Primary key
                    entity.HasKey(p => p.ProductId);
                    //Index: tang toc do tim kiem
                    entity.HasIndex(p => p.Price).HasDatabaseName("index-sanpham-price");
                    //Relationship
                    //HasOne: 1 category co nhieu product
                    entity.HasOne(p => p.Category)
                          .WithMany() //category khong co property la Products
                          .HasForeignKey("CateId")
                          .OnDelete(DeleteBehavior.Cascade) //khi xoa category thi product cung bi xoa , NoAction: khong lam gi, Restrict: khong xoa, SetNull: set null
                        //HasConstraintName: dat ten cho khoa ngoai
                          .HasConstraintName("khoa-ngoai-sanpham-category");

                    entity.HasOne(p => p.Category2)
                          //Colection navigation
                          .WithMany(c => c.Products) //category co property la Products, khi lay category thi lay luon product thuoc category do
                          .HasForeignKey("CateId2")
                          .OnDelete(DeleteBehavior.NoAction)
                          .HasConstraintName("khoa-ngoai-sanpham-category2");

                    entity.Property(p => p.Name)
                          //co the vua dung attribute vua dung fluent API, nhung dung FluentAPI thi se ghi de len attribute
                          .HasColumnName("Title") // ten cot trong CSDL
                          .HasColumnType("nvarchar")
                          .HasMaxLength(60)
                          //IsRequire: khong cho null, false: cho null
                          .IsRequired(true);
                });

            modelBuilder.Entity<CategoryDetail>(
                entity =>
                {
                    //thiet lap mqh 1-1 
                    entity.HasOne(cd => cd.Category)
                          .WithOne(c => c.CategoryDetail)
                          .HasForeignKey<CategoryDetail>(c => c.CategoryDetailId)
                          .OnDelete(DeleteBehavior.Cascade); //khi xoa category thi categorydetail cung bi xoa

                });
        }
    }
}
