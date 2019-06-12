using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;


namespace Pollen.DataLayer.Repositories
{
    public class FormRepository : IRepository<Form>
    {
        PollenContext context;
        public FormRepository(PollenContext context)
        {
            this.context = context;
        }
        public void Create(Form t)
        {
            context.Forms.Add(t);
        }
        public void Delete(int id)
        {
            var form = context.Forms.Find(id);
            context.Forms.Remove(form);
        }

        public IEnumerable<Form> Find(Func<Form, bool> predicate)
        {
            return context.Forms
                          .Include(g => g.Families)
                          .Where(predicate)
                          .ToList();
        }



        public Form Get(int id)
        {
            return context.Forms.Find(id);
        }

        public IEnumerable<Form> GetAll()
        {
            return context.Forms.Include(g => g.Families);
        }

        public IEnumerable<Form> GetSelected(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Form t)
        {
            context.Entry<Form>(t).State = EntityState.Modified;
        }
    }
}
