using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;

namespace Pollen.DataLayer.Repositories
{
    public class EquatorialImageRepository : IRepository<EquatorialImage>
    {
        PollenContext context;
        public EquatorialImageRepository(PollenContext context)
        {
            this.context = context;
        }
        public void Create(EquatorialImage t)
        {
            context.EquatorialImages.Add(t);
        }
        public void Delete(int id)
        {
            var VEquatorialImage = context.EquatorialImages.Find(id);
            context.EquatorialImages.Remove(VEquatorialImage);
        }

        public IEnumerable<EquatorialImage> Find(Func<EquatorialImage, bool> predicate)
        {
            return context.EquatorialImages
                          .Include(g => g.PlantType)
                          .Where(predicate)
                          .ToList();
        }

        public EquatorialImage Get(int id)
        {
            return context.EquatorialImages.Find(id);
        }

        public IEnumerable<EquatorialImage> GetAll()
        {
            return context.EquatorialImages.Include(g => g.PlantType);
        }

        public IEnumerable<EquatorialImage> GetSelected(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EquatorialImage t)
        {
            context.Entry<EquatorialImage>(t).State = EntityState.Modified;
        }
    }
}
