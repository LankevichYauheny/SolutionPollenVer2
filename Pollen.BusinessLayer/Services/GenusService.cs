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
    public class GenusService : IGenusService
    {
        IUnitOfWork dataBase;
        public GenusService(string name)
        {
            dataBase = new EFUnitOfWork(name);
        }
        public void AddPlantTypeToGenus(int genusId, PlantTypeViewModel plantType)
        {
            Mapper.Reset();
            var genus = dataBase.Genera.Get(genusId);
            // конфигурирование AutoMapper. Отображение объекта PlantTypeViewModel на объект PlantType. Тип слева - тип источника, а тип справа - тип назначения
            Mapper.Initialize(cfg => cfg.CreateMap<PlantTypeViewModel, PlantType>());
            var plant = Mapper.Map<PlantType>(plantType);
            genus.PlantTypes.Add(plant);
            dataBase.Save();
        }
        public void CreateGenus(GenusViewModel genus)
        {
            throw new NotImplementedException();
        }

        public void DeleteGenus(int genusId)
        {
            dataBase.Genera.Delete(genusId);
            dataBase.Save();
        }

        public GenusViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<GenusViewModel> GetAll()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Genus, GenusViewModel>();
                cfg.CreateMap<PlantType, PlantTypeViewModel>();
                cfg.CreateMap<PolarGrainShape, PolarGrainShapeViewModel>();
                cfg.CreateMap<EquatorialGrainShape, EquatorialGrainShapeViewModel>();
            });

            // Отображение List<Genus> на ObservableCollection<GenusViewModel>
            var genus = Mapper.Map<ObservableCollection<GenusViewModel>>(dataBase.Genera.GetAll());
            return genus;
        }

        public void RemovePlantTypeFromGenus(int genusId, int plantTypeId)
        {
            throw new NotImplementedException();
        }

        public void UpdateGenus(GenusViewModel genus)
        {
            throw new NotImplementedException();
        }
    }
}
