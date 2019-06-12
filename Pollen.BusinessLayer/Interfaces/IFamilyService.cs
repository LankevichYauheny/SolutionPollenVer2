using System.Collections.ObjectModel;
using Pollen.BusinessLayer.ViewModels;

namespace Pollen.BusinessLayer.Interfaces
{
    public interface IFamilyService
    {
        ObservableCollection<FamilyViewModel> GetAll();
        FamilyViewModel Get(int id);
        void AddGenusToFamily(int familyId, GenusViewModel genus);
        void RemoveGenusFromFamily(int familyId, int genusId);
        void CreateFamily(FamilyViewModel family);
        void DeleteFamily(int familyId);
        void UpdateFamily(FamilyViewModel family);
    }
}
