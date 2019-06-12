using System.Collections.ObjectModel;
using Pollen.BusinessLayer.ViewModels;


namespace Pollen.BusinessLayer.Interfaces
{
    public interface IEquatorialGrainShapeService
    {
        ObservableCollection<EquatorialGrainShapeViewModel> GetAll();
        EquatorialGrainShapeViewModel Get(int id);
        void AddPlantTypeToEquatorialGrainShape(int equatorialGrainShapeId, PlantTypeViewModel plantType);
        void RemovePlantTypeFromEquatorialGrainShape(int equatorialGrainShapeId, int plantTypeId);
        void CreateEquatorialGrainShape(EquatorialGrainShapeViewModel equatorialGrainShape);
        void DeleteEquatorialGrainShape(int equatorialGrainShapeId);
        void UpdateEquatorialGrainShape(EquatorialGrainShapeViewModel equatorialGrainShape);
    }
}
