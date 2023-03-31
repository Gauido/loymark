using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public int Id_User { get; set; }

        [ForeignKey("Id_User")]
        public virtual User User { get; set; }
    }
}
