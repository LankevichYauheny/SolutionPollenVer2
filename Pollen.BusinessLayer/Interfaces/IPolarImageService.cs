using System.Collections.ObjectModel;
using Pollen.BusinessLayer.ViewModels;

namespace Pollen.BusinessLayer.Interfaces
{
    public interface IPolarImageService
    {
        ObservableCollection<PolarImageViewModel> GetAll();
        PolarImageViewModel Get(int id);
        void AddPlantTypeToPolarImage(int polarImageId, PlantTypeViewModel plantType);
        void RemovePlantTypeFromPolarImage(int polarImageId, int plantTypeId);
        void CreatePolarImage(PolarImageViewModel polarImage);
        void DeletePolarImage(int polarImageId);
        void UpdatePolarImagee(PolarGrainShapeViewModel polarImage);
    }
}
