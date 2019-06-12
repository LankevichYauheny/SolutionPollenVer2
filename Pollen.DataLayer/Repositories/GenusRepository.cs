using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;

namespace Pollen.DataLayer.Repositories
{
    public class GenusRepository : IRepository<Genus>
    {
        PollenContext context;
        public GenusRepository(PollenContext context)
        {
            this.context = context;
        }
        public void Create(Genus t)                  //Метод Create добавляет объект типа <T> в базу данных
        {
            context.Genera.Add(t);
        }
        public void Delete(int id)
        {
            var genus = context.Genera.Find(id);
            context.Genera.Remove(genus);
        }

        public IEnumerable<Genus> Find(Func<Genus, bool> predicate)//Метод Find осуществляет поиск объекта, удовлетворяющего условию predicate
        {
            return context.Genera
                          .Include(g => g.PlantTypes)
                          .Where(predicate)
                          .ToList();
        }

        public Genus Get(int id)
        {
            return context.Genera.Find(id);
        }

        public IEnumerable<Genus> GetAll()
        {
            return context.Genera.Include(g => g.PlantTypes)
                                  .ToList();
        }

        public IEnumerable<Genus> GetSelected(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Genus t)
        {
            context.Entry<Genus>(t).State = EntityState.Modified;
        }
    }
}
