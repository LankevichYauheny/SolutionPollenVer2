using System.Collections.ObjectModel;

namespace Pollen.BusinessLayer.ViewModels
{
    public class PlantTypeViewModel
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameRU { get; set; }
        public string AdditionalNameRU { get; set; }
        public string DustingTime { get; set; }
        public string PollenSculpture { get; set; }
        public string ApertureStructure { get; set; }
        public int ApertureNumber { get; set; }
        public string AperturePosition { get; set; }
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
        public int ID_Genus { get; set; }
        public ObservableCollection<EquatorialGrainShapeViewModel> EquatorialGrainShapes { get; set; }
        public ObservableCollection<PolarGrainShapeViewModel> PolarGrainShapes { get; set; }

        public ObservableCollection<PolarImageViewModel> PolarImages { get; set; }
        public ObservableCollection<EquatorialImageViewModel> EquatorialImages { get; set; }
        public ObservableCollection<AbnormalImageViewModel> AbnormalImages { get; set; }
    }
}
