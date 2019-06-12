using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pollen.DataLayer.Entities
{
    [Table("Families")]
    public class Family
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Family()
        {
            Genera = new List<Genus>();
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
        public int ID_Form { get; set; }
        public Form Form { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public List<Genus> Genera { get; set; }
    }
}
