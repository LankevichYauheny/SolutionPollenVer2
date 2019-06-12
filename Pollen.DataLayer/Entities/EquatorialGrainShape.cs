using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;// здесь содержится большинство классов аннотаций 
                                            //Аннотации представляют настройку сопоставления моделей и таблиц с помощью атрибутов. 
using System.ComponentModel.DataAnnotations.Schema;

namespace Pollen.DataLayer.Entities
{
    [Table("EquatorialGrainShapes")]
    public class EquatorialGrainShape
    {
        public EquatorialGrainShape()
        {
            PlantTypes = new List<PlantType>();
        }
        [Key] //установка свойства в качестве первичного ключа
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        //навигационное свойство
        public List<PlantType> PlantTypes { get; set; }
    }
}
