using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.domain.Entities
{
    [Table("tag")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("descricao")]
        public string Description { get; set; }

        public ICollection<NewTag> NewsTag { get; set; }
    }
}
