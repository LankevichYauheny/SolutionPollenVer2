using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;

namespace Pollen.DataLayer.Repositories
{
    public class AbnormalImageRepository : IRepository<AbnormalImage>
    {
        PollenContext context;
        public AbnormalImageRepository(PollenContext context)
        {
            this.context = context;
        }
        public void Create(AbnormalImage t)
        {
            context.AbnormalImages.Add(t);
        }
        public void Delete(int id)
        {
            var image = context.AbnormalImages.Find(id);
            context.AbnormalImages.Remove(image);
        }

        public IEnumerable<AbnormalImage> Find(Func<AbnormalImage, bool> predicate)
        {
            return context.AbnormalImages
                          .Include(g => g.PlantTypes)
                          .Where(predicate)
                          .ToList();
        }

        public AbnormalImage Get(int id)
        {
            return context.AbnormalImages.Find(id);
        }

        public IEnumerable<AbnormalImage> GetAll()
        {
            return context.AbnormalImages.Include(g => g.PlantTypes);
        }

        public IEnumerable<AbnormalImage> GetSelected(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AbnormalImage t)
        {
            context.Entry<AbnormalImage>(t).State = EntityState.Modified;
        }
    }
}
