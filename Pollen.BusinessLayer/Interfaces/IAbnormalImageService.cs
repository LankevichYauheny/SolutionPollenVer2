using System.Collections.ObjectModel;
using Pollen.BusinessLayer.ViewModels;

namespace Pollen.BusinessLayer.Interfaces
{
    public interface IAbnormalImageService
    {
        ObservableCollection<AbnormalImageViewModel> GetAll();
        AbnormalImageViewModel Get(int id);
        void AddPlantTypeToAbnormalImage(int abnormalImageId, PlantTypeViewModel plantType);
        void RemovePlantTypeFromAbnormalImage(int abnormalImageId, int plantTypeId);
        void CreateAbnormalImage(AbnormalImageViewModel abnormalImage);
        void DeleteAbnormalImage(int abnormalImageId);
        void UpdateAbnormalImagee(PolarGrainShapeViewModel abnormalImage);
    }
}
