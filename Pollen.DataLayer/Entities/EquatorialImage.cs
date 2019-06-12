using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pollen.DataLayer.Entities
{
    [Table("EquatorialImages")]
    public class EquatorialImage
    {
        public EquatorialImage()
        {
            PlantTypes = new List<PlantType>();
        }

        [Key]
        public Guid FileID { get; set; }

        public byte[] FileContents { get; set; }

        [StringLength(50)]
        public string Caption { get; set; }


        //навигационное свойство
        public List<PlantType> PlantTypes { get; set; }
    }
}
