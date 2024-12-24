using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS11_EF.Model
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }

        [StringLength(100)]
        public string Name { set; get; }

        [Column(TypeName = "ntext")]   // Cột (trường) kiểu ntext trong SQL Server
        public string Description { set; get; }
        //Collection navigation property
        public virtual List<Product> Products { set; get; }
        //Collect Navigation: Khong tao ra FK
        public CategoryDetail CategoryDetail { get; set; }

    }
}
