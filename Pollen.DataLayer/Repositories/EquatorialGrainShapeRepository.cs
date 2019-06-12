using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;

namespace Pollen.DataLayer.Repositories
{
    public class EquatorialGrainShapeRepository : IRepository<EquatorialGrainShape>
    {
        PollenContext context;
        public EquatorialGrainShapeRepository(PollenContext context)
        {
            this.context = context;
        }
        public void Create(EquatorialGrainShape t)
        {
            context.EquatorialGrainShapes.Add(t);
        }
        public void Delete(int id)
        {
            var shape = context.EquatorialGrainShapes.Find(id);
            context.EquatorialGrainShapes.Remove(shape);
        }

        public IEnumerable<EquatorialGrainShape> Find(Func<EquatorialGrainShape, bool> predicate)
        {
            return context.EquatorialGrainShapes
                          .Include(g => g.PlantTypes)
                          .Where(predicate)
                          .ToList();
        }

        public EquatorialGrainShape Get(int id)
        {
            return context.EquatorialGrainShapes.Find(id);
        }

        public IEnumerable<EquatorialGrainShape> GetAll()
        {
            return context.EquatorialGrainShapes.Include(g => g.PlantTypes);
        }

        public IEnumerable<EquatorialGrainShape> GetSelected(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EquatorialGrainShape t)
        {
            context.Entry<EquatorialGrainShape>(t).State = EntityState.Modified;
        }
    }
}
