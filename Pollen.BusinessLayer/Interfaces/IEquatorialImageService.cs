using System.Collections.ObjectModel;
using Pollen.BusinessLayer.ViewModels;


namespace Pollen.BusinessLayer.Interfaces
{
    public interface IEquatorialImageService
    {
        ObservableCollection<EquatorialImageViewModel> GetAll();
        EquatorialImageViewModel Get(int id);
        void AddPlantTypeToEquatorialImage(int equatorialImageId, PlantTypeViewModel plantType);
        void RemovePlantTypeFromEquatorialImage(int equatorialImageId, int plantTypeId);
        void CreateEquatorialImage(EquatorialImageViewModel equatorialImage);
        void DeleteEquatorialImage(int equatorialImageId);
        void UpdateEquatorialImagee(PolarGrainShapeViewModel equatorialImage);
    }
}
