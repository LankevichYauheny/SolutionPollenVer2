using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pollen.DataLayer.Entities
{
    [Table("PolarImages")]
    public class PolarImage
    {
        public PolarImage()
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
