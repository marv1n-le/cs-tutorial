using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS11_EF.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { set; get; }

        [Required]
        [StringLength(50)]
        [Column("Ten san pham", TypeName = "ntext")]
        public string Name { set; get; }

        public double Price { get; set; }
        public int? CateId { get; set; }
        //cách tạo FK
        // [Required] // khi them product phai co category, khi xoa category thi product cung bi xoa
        //FK nên để ở bảng nhiều (1 product có 1 category) (1 category có nhiều product)
        [ForeignKey("CateId")] // khai bao khoa ngoai, tu dinh nghia
        public virtual Category Category { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine($"ID: {ProductId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"CateID: {CateId}");
        }

        //Inverse Property: Tạo ra FK
        //Tao ra them 1 FK trong product (1 product co 2 category)
        public int? CateId2 { get; set; }
  
        [ForeignKey("CateId2")]
        [InverseProperty("Products")]

        public virtual Category Category2 { get; set; }
    }
}
