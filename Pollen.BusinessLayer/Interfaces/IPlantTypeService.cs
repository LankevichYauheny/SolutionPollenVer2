using System.Collections.ObjectModel;
using Pollen.BusinessLayer.ViewModels;
using System.Collections.Generic;

namespace Pollen.BusinessLayer.Interfaces
{
    public interface IPlantTypeService
    {
        ObservableCollection<PlantTypeViewModel> GetAll();
        SortedList<int, string> GetSpeciesOfForm(int idForm);
        PlantTypeViewModel Get(int id);
        void AddPolarImageToPlantType(int plantTypeId, PolarImageViewModel polarImage);
        void AddEquatorialImageToPlantType(int plantTypeId, EquatorialImageViewModel equatorialImage);
        void AddAbnormalImageToPlantType(int plantTypeId, AbnormalImageViewModel abnormalImage);

        void AddEquatorialGrainShapeToPlantType(int plantTypeId, EquatorialGrainShapeViewModel equatorialGrainShape);
        void AddPolarGrainShapeToPlantType(int plantTypeId, PolarGrainShapeViewModel polarGrainShape);


        void RemovePolarImageFromPlantType(int plantTypeId, int polarImageId);
        void RemoveEquatorialImageFromPlantType(int plantTypeId, int equatorialImageId);
        void RemoveAbnormalImageFromPlantType(int plantTypeId, int abnormalImageId);
        void RemoveEquatorialGrainShapeFromPlantType(int plantTypeId, int equatorialGrainShapeId);
        void RemovePolarGrainShapeFromPlantType(int plantTypeId, int polarGrainShapeId);


        void CreatePlantType(PlantTypeViewModel plantType);
        void DeletePlantType(int plantTypeId);
        void UpdatePlantType(PlantTypeViewModel plantType);
    }
}
