using System.Collections.ObjectModel;using Pollen.BusinessLayer.ViewModels;

namespace Pollen.BusinessLayer.Interfaces
{
    public interface IGenusService
    {
        ObservableCollection<GenusViewModel> GetAll();
        GenusViewModel Get(int id);
        void AddPlantTypeToGenus(int genusId, PlantTypeViewModel plantType);
        void RemovePlantTypeFromGenus(int genusId, int plantTypeId);
        void CreateGenus(GenusViewModel genus);
        void DeleteGenus(int genusId);
        void UpdateGenus(GenusViewModel genus);
    }
}
