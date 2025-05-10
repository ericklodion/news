using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.domain.Entities
{
    [Table("noticia")]
    public class New
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("titulo")]
        public string Title { get; set; }

        [Required]
        [Column("texto")]
        public string Text { get; set; }

        [Required]
        [Column("usuarioid")]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<NewTag> NewTags { get; set; }
    }
}
