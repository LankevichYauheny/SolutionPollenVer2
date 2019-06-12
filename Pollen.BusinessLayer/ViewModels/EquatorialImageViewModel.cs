using System.Collections.ObjectModel;


namespace Pollen.BusinessLayer.ViewModels
{
    public class EquatorialImageViewModel
    {
        public string stream_id { get; set; }
        public string name { get; set; }
        public string unc_path { get; set; }
        public ObservableCollection<PlantTypeViewModel> PlantTypes { get; set; }
    }
}
