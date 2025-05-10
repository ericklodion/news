using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace news.domain.Entities
{
    [Table("noticiatag")]
    public class NewTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("noticiaid")]
        public long NewId { get; set; }

        [Column("tagid")]
        public long TagId { get; set; }

        [JsonIgnore]
        public New New { get; set; }

        [JsonIgnore]
        public Tag Tag { get; set; }
    }
}
