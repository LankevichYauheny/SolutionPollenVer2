using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Pollen.DataLayer.Entities
{
    [Table("PolarGrainShapes")]
    public class PolarGrainShape
    {
        public PolarGrainShape()
        {
            PlantTypes = new List<PlantType>();
        }
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public List<PlantType> PlantTypes { get; set; }
    }
}
