using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;


namespace Pollen.DataLayer.Repositories
{
    public class PolarImageRepository : IRepository<PolarImage>
    {
        PollenContext context;
        public PolarImageRepository(PollenContext context)
        {
            this.context = context;
        }
        public void Create(PolarImage t)
        {
            context.PolarImages.Add(t);
        }
        public void Delete(int id)
        {
            var image = context.PolarImages.Find(id);
            context.PolarImages.Remove(image);
        }

        public IEnumerable<PolarImage> Find(Func<PolarImage, bool> predicate)
        {
            return context.PolarImages
                          .Include(g => g.PlantType)
                          .Where(predicate)
                          .ToList();
        }

        public PolarImage Get(int id)
        {
            return context.PolarImages.Find(id);
        }

        public IEnumerable<PolarImage> GetAll()
        {
            return context.PolarImages.Include(g => g.PlantType);
        }

        public IEnumerable<PolarImage> GetSelected(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PolarImage t)
        {
            context.Entry<PolarImage>(t).State = EntityState.Modified;
        }
    }
}
