using System;
using System.Collections.Generic;
using System.Linq;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.EntityFrameworkContext;
using System.Data.Entity;

namespace Pollen.DataLayer.Repositories
{
    public class PlantTypeRepository : IRepository<PlantType>
    {
        PollenContext db;
        public PlantTypeRepository(PollenContext context)
        {
            this.db = context;
        }
        public void Create(PlantType t)
        {
            db.PlantTypes.Add(t);
        }
        public void Delete(int id)
        {
            var species = db.PlantTypes.Find(id);
            db.PlantTypes.Remove(species);
        }

        public IEnumerable<PlantType> Find(Func<PlantType, bool> predicate)
        {
            return db.PlantTypes.Include(g => g.Genus.Family.Form)
                                     .Where(predicate);
        }

        public SortedList<int, string> GetPlantTypesOfForm(int idForm)
        {
            SortedList<int, string> plantTypes = new SortedList<int, string>();
            var result = from form in db.Forms
                         join family in db.Families on form.ID equals family.ID_Form
                         join genus in db.Genera on family.ID equals genus.ID_Family
                         join plantType in db.PlantTypes on genus.ID equals plantType.ID_Genus
                         where form.ID == idForm
                         select new
                         { ID = plantType.ID,
                           Name = plantType.NameRU};

            foreach(var r in result)
            {
                plantTypes.Add(r.ID, r.Name);
            }
            return plantTypes;
        }

               
        public PlantType Get(int id)
        {
            return db.PlantTypes.Find(id);
        }

        public IEnumerable<PlantType> GetPlantTypes(int idForm)
        {
            return db.PlantTypes.Include(p => p.PolarGrainShapes)
                .Include(p => p.EquatorialGrainShapes)
                .Include(p => p.Genus)
                .Include(p => p.Genus.Family)
                .Include(p => p.Genus.Family.Form)
                .Include(p => p.PolarImages)
                .Include(p => p.EquatorialImages)
                .Include(p => p.AbnormalImages)
                .Include(p => p.PolarGrainShapes)
                .Include(p => p.EquatorialGrainShapes)
                .Where(p =>p.Genus.Family.Form.ID == idForm)
                .ToList();
        }

        public IEnumerable<PlantType> GetAll()
        {
            return db.PlantTypes.Include(p => p.PolarGrainShapes)
                                .Include(p => p.EquatorialGrainShapes)
                                //.Include(p => p.AbnormalImages)
                                //.Include(p => p.EquatorialImages)
                                //.Include(p => p.AbnormalImages)
                                //.Include(p => p.Genus)
                                .ToList();
        }

        public void Update(PlantType t)
        {
            db.Entry<PlantType>(t).State = EntityState.Modified;
        }
    }
}
