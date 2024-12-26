using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS12___Migration.Model
{
    [Table("ArticleTag")]
    public class ArticleTag
    {
        [Key]
        public int ArticleTagId { get; set; }
        [ForeignKey("TagId")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        [ForeignKey("ArticleId")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
