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

        public decimal Price { get; set; }
        public int? CateId { get; set; }
        //cách tạo FK
       // [Required] // khi them product phai co category, khi xoa category thi product cung bi xoa
        [ForeignKey("CateId")] // khai bao khoa ngoai, tu dinh nghia
        public Category Category { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine($"ID: {ProductId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Provider: {Price}");
        }
    }
}
