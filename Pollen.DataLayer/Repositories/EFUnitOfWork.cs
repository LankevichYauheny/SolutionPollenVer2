//данный класс работает с базой данных через классы Entity Framework
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.EntityFrameworkContext;
using System;


namespace Pollen.DataLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        PollenContext context;

        FormRepository formRepository;
        FamilyRepository familyRepository;
        GenusRepository genusRepository;
        EquatorialGrainShapeRepository equatorialGrainShapeRepository;
        PolarGrainShapeRepository polarGrainShapeRepository;
        PolarImageRepository PolarImageRepository;
        EquatorialImageRepository EquatorialImageRepository;
        AbnormalImageRepository AbnormalImageRepository;
        PlantTypeRepository plantTypeRepository;

        public EFUnitOfWork(string name)
        {
            context = new PollenContext(name);  
        }

        public IRepository<Form> Forms
        {
            get
            {
                if (formRepository == null)
                {
                    formRepository = new FormRepository(context);
                }
                return formRepository;
            }
        }

        public IRepository<Family> Families
        {
            get
            {
                if (familyRepository == null)
                {
                    familyRepository = new FamilyRepository(context);
                }
                return familyRepository;
            }
        }

        public IRepository<Genus> Genera
        {
            get
            {
                if (genusRepository == null)
                {
                    genusRepository = new GenusRepository(context);
                }
                return genusRepository;
            }
        }

        public IRepository<EquatorialGrainShape> EquatorialGrainShapes
        {
            get
            {
                if (equatorialGrainShapeRepository == null)
                {
                    equatorialGrainShapeRepository = new EquatorialGrainShapeRepository(context);
                }
                return equatorialGrainShapeRepository;
            }
        }

        public IRepository<PolarGrainShape> PolarGrainShapes
        {
            get
            {
                if (polarGrainShapeRepository == null)
                {
                    polarGrainShapeRepository = new PolarGrainShapeRepository(context);
                }
                return polarGrainShapeRepository;
            }
        }

        public IRepository<EquatorialImage> EquatorialImages
        {
            get
            {
                if (EquatorialImageRepository == null)
                {
                    EquatorialImageRepository = new EquatorialImageRepository(context);
                }
                return EquatorialImageRepository;
            }
        }

        public IRepository<AbnormalImage> AbnormalImages
        {
            get
            {
                if (AbnormalImageRepository == null)
                {
                    AbnormalImageRepository = new AbnormalImageRepository(context);
                }
                return AbnormalImageRepository;
            }
        }

        public IRepository<PolarImage> PolarImages
        {
            get
            {
                if (PolarImageRepository == null)
                {
                    PolarImageRepository = new PolarImageRepository(context);
                }
                return PolarImageRepository;
            }
        }

        public PlantTypeRepository PlantTypes
        {
            get
            {
                if (plantTypeRepository == null)
                {
                    plantTypeRepository = new PlantTypeRepository(context);
                }
                return plantTypeRepository;
            }
        }
        public void Save()
        {
                context.SaveChanges();
        }

        // Реализация интерфейса IDisposable
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
