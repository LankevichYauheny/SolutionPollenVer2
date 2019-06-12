using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pollen.DataLayer.Entities
{
    [Table("Forms")]
    public class Form
    {
        public Form()
        {
            Families = new List<Family>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NameRU { get; set; }



        //навигационное свойство
        public List<Family> Families { get; set; }
    }
}
