using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;


namespace Pollen.DataLayer.Repositories
{
    public class FamilyRepository : IRepository<Family>
    {
        PollenContext context;
        public FamilyRepository(PollenContext context)
        {
            this.context = context;
        }
        public void Create(Family t)
        {
            context.Families.Add(t);
        }
        public void Delete(int id)
        {
            var family = context.Families.Find(id);
            context.Families.Remove(family);
        }

        public IEnumerable<Family> Find(Func<Family, bool> predicate)
        {
            return context.Families
                          .Include(g => g.Genera)
                          .Where(predicate)
                          .ToList();
        }

        public Family Get(int id)
        {
            return context.Families.Find(id);
        }

        public IEnumerable<Family> GetAll()
        {
            return context.Families.Include(g => g.Genera);
        }

        public IEnumerable<Family> GetSelected(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Family t)
        {
            context.Entry<Family>(t).State = EntityState.Modified;
        }
    }
}
