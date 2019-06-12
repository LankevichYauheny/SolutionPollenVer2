using System;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.Repositories;


//На случай, если контекст данных будет подразумевать освобождение или закрытие подключений, интерфейс репозитория применяет интерфейс IDisposable
namespace Pollen.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Form> Forms { get; }
        IRepository<Family> Families { get; }
        IRepository<Genus> Genera { get; }
        IRepository<EquatorialGrainShape> EquatorialGrainShapes { get; }
        IRepository<PolarGrainShape> PolarGrainShapes { get; }
        IRepository<EquatorialImage> EquatorialImages { get; }
        IRepository<AbnormalImage> AbnormalImages { get; }
        IRepository<PolarImage> PolarImages { get; }
        PlantTypeRepository PlantTypes { get; }
        void Save();
    }
}
