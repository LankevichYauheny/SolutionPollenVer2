using System.Collections.ObjectModel;

namespace Pollen.BusinessLayer.ViewModels
{
    public class FamilyViewModel
    {
        public int ID { get; set; }
        public string NameEN { get; set; }
        public string NameRU { get; set; }
        public ObservableCollection<GenusViewModel> Genera { get; set; }
    }
}
