using System.Collections.ObjectModel;
using Pollen.BusinessLayer.ViewModels;


namespace Pollen.BusinessLayer.Interfaces
{
    public interface IPolarlGrainShapeService
    {
        ObservableCollection<PolarGrainShapeViewModel> GetAll();
        PolarGrainShapeViewModel Get(int id);
        void AddPlantTypeToPolarGrainShape(int polarialGrainShapeId, PlantTypeViewModel plantType);
        void RemovePlantTypeFromPolarialGrainShape(int polarialGrainShapeId, int plantTypeId);
        void CreatePolarialGrainShape(PolarGrainShapeViewModel polarGrainShape);
        void DeletePolarGrainShape(int polarGrainShapeId);
        void UpdatePolarGrainShape(PolarGrainShapeViewModel polarGrainShape);
    }
}
