using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS12___Migration.Model
{
    [Table("Article")]
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
    }
}
