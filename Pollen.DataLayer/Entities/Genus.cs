using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pollen.DataLayer.Entities
{
    [Table("Genera")]
    public class Genus
    {
        public Genus()
        {
            PlantTypes = new List<PlantType>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NameEN { get; set; }

        [Required]
        [StringLength(50)]
        public string NameRU { get; set; }



        //навигационные свойства
        public int ID_Family { get; set; }

        public Family Family { get; set; }

        public List<PlantType> PlantTypes { get; set; }
    }
}
