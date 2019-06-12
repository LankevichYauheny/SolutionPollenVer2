using System.Collections.ObjectModel;


namespace Pollen.BusinessLayer.ViewModels
{
    public class EquatorialGrainShapeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ObservableCollection<PlantTypeViewModel> PlantTypes { get; set; }
    }
}
