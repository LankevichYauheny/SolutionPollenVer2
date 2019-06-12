using System.Collections.ObjectModel;

namespace Pollen.BusinessLayer.ViewModels
{
    public class FormViewModel
    {
        public int ID { get; set; }
        public string NameRU { get; set; }
        public ObservableCollection<FamilyViewModel> Families { get; set; }
    }
}
