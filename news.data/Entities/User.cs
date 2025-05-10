using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.domain.Entities
{
    [Table("usuario")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("nome")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("senha")]
        public string Password { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("email")]
        public string Email { get; set; }
    }
}
