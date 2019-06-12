using System.Collections.ObjectModel;
using Pollen.BusinessLayer.ViewModels;

namespace Pollen.BusinessLayer.Interfaces
{
    public interface IFormService
    {
        ObservableCollection<FormViewModel> GetAll();
        FormViewModel Get(int id);
        void AddFamilyToForm(int formId, FamilyViewModel family);
        void RemoveFamilyFromForm(int formId, int familyId);
        void CreateForm(FormViewModel form); //Метод Create добавляет объект типа FormViewModel в базу данных.
        void DeleteForm(int formId);
        void UpdateForm(FormViewModel form);
    }
}
