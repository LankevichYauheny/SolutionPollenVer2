using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pollen.DataLayer.Entities
{
    [Table("PlantTypes")]
    public class PlantType
    {
        public PlantType()
        {
            EquatorialGrainShapes = new List<EquatorialGrainShape>();
            PolarGrainShapes = new List<PolarGrainShape>();
            PolarImages = new List<PolarImage>();
            EquatorialImages = new List<EquatorialImage>();
            AbnormalImages = new List<AbnormalImage>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NameEN { get; set; }

        [Required]
        [StringLength(50)]
        public string NameRU { get; set; }

        [StringLength(50)]
        public string AdditionalNameRU { get; set; }

        [Required]
        [StringLength(50)]
        public string DustingTime { get; set; }

        [Required]
        [StringLength(50)]
        public string PollenSculpture { get; set; }

        [Required]
        [StringLength(30)]
        public string ApertureStructure { get; set; }

        public int ApertureNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string AperturePosition { get; set; }

        [Required]
        [StringLength(30)]
        public string ApertureType { get; set; }
        public string PollenFeatures { get; set; }
        public decimal PollenPolarMinSize { get; set; }
        public decimal PollenPolarMaxSize { get; set; }
        public decimal PollenEquatorialMinSize { get; set; }
        public decimal PollenEquatorialMaxSize { get; set; }
        public decimal ExinePolarMinThickness { get; set; }
        public decimal ExinePolarMaxThickness { get; set; }
        public decimal ExineEquatorialMinThickness { get; set; }
        public decimal ExineEquatorialMaxThickness { get; set; }
        public string PollenColor { get; set; }

        //навигационные свойства
        public int ID_Genus { get; set; }
        public Genus Genus { get; set; }
        public List<EquatorialGrainShape> EquatorialGrainShapes { get; set; }
        public List<PolarGrainShape> PolarGrainShapes { get; set; }
        public List <PolarImage> PolarImages { get; set; }
        public List<EquatorialImage> EquatorialImages { get; set; }
        public List<AbnormalImage> AbnormalImages { get; set; }
    }
}
