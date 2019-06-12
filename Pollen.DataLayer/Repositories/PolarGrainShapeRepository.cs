using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;

namespace Pollen.DataLayer.Repositories
{
    public class PolarGrainShapeRepository : IRepository<PolarGrainShape>
    {
        PollenContext context;
        public PolarGrainShapeRepository(PollenContext context)
        {
            this.context = context;
        }
        public void Create(PolarGrainShape t)
        {
            context.PolarGrainShapes.Add(t);
        }
        public void Delete(int id)
        {
            var shape = context.PolarGrainShapes.Find(id);
            context.PolarGrainShapes.Remove(shape);
        }

        public IEnumerable<PolarGrainShape> Find(Func<PolarGrainShape, bool> predicate)
        {
            return context.PolarGrainShapes
                          .Include(g => g.PlantTypes)
                          .Where(predicate)
                          .ToList();
        }

        public PolarGrainShape Get(int id)
        {
            return context.PolarGrainShapes.Find(id);
        }

        public IEnumerable<PolarGrainShape> GetAll()
        {
            return context.PolarGrainShapes.Include(g => g.PlantTypes);
        }

        public void Update(PolarGrainShape t)
        {
            context.Entry<PolarGrainShape>(t).State = EntityState.Modified;
        }
    }
}
