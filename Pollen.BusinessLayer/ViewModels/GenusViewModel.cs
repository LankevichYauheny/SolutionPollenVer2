using System.Collections.ObjectModel;

namespace Pollen.BusinessLayer.ViewModels
{
    public class GenusViewModel
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameRU { get; set; }
        public int ID_Family { get; set; }
        public ObservableCollection<PlantTypeViewModel> PlantTypes { get; set; }
    }
}
