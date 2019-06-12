using System;
using System.Collections.ObjectModel;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.Repositories;
using AutoMapper;



namespace Pollen.BusinessLayer.Services
{
    public class FamilyService : IFamilyService
    {
        IUnitOfWork dataBase;
        public FamilyService(string name)
        {
            dataBase = new EFUnitOfWork(name);
        }
        public void AddGenusToFamily(int familyId, GenusViewModel genus)
        {
            Mapper.Reset();
            var fam = dataBase.Families.Get(familyId);
            // конфигурирование AutoMapper. Отображение объекта GenusViewModel на объект Genus.
            // Тип слева - тип источника, а тип справа - тип назначения.
            Mapper.Initialize(cfg => cfg.CreateMap<GenusViewModel, Genus>());
            var gen = Mapper.Map<Genus>(genus);
            fam.Genera.Add(gen);
            dataBase.Save();
        }

        public void CreateFamily(FamilyViewModel family)
        {
            throw new NotImplementedException();
        }

        public void DeleteFamily(int familyId)
        {
            dataBase.Families.Delete(familyId);
            dataBase.Save();
        }

        public FamilyViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<FamilyViewModel> GetAll()
        {
            Mapper.Reset();
            //Конфигурировани AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Family, FamilyViewModel>();
            });

            //Отображение List<Family> на ObservableCollection< FamilyViewModel >
            var family = Mapper.Map<ObservableCollection<FamilyViewModel>>(dataBase.Families.GetAll());
            return family;
        }

        public void RemoveGenusFromFamily(int familyId, int genusId)
        {
            throw new NotImplementedException();
        }

        public void UpdateFamily(FamilyViewModel family)
        {
            throw new NotImplementedException();
        }
    }
}
