using System;
using System.Collections.ObjectModel;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.DataLayer.Interfaces;
using Pollen.DataLayer.Entities;
using Pollen.DataLayer.Repositories;
using System.Collections.Generic;
using AutoMapper;


namespace Pollen.BusinessLayer.Services
{
    public class PlantTypeService : IPlantTypeService
    {
        IUnitOfWork dataBase;
        public PlantTypeService(string name)
        {
            dataBase = new EFUnitOfWork(name);
        }

        public void AddPolarImageToPlantType(int plantTypeId, PolarImageViewModel polarImage)
        {
            Mapper.Reset();
            var plantType = dataBase.PlantTypes.Get(plantTypeId);

            // конфигурирование AutoMapper. Отображение объекта PolarImageViewModel на объект PolarImage. Тип слева - тип источника, а тип справа - тип назначения
            Mapper.Initialize(cfg => cfg.CreateMap<PolarImageViewModel, PolarImage>());
            var img = Mapper.Map<PolarImage>(polarImage);
            plantType.PolarImages.Add(img);
            dataBase.Save();
        }

        public void AddEquatorialImageToPlantType(int plantTypeId, EquatorialImageViewModel equatorialImage)
        {
            Mapper.Reset();
            var plantType = dataBase.PlantTypes.Get(plantTypeId);

            // конфигурирование AutoMapper. Отображение объекта EquatorialImageViewModel на объект EquatorialImage. Тип слева - тип источника, а тип справа - тип назначения
            Mapper.Initialize(cfg => cfg.CreateMap<EquatorialImageViewModel, EquatorialImage>());
            var img = Mapper.Map<EquatorialImage>(equatorialImage);
            plantType.EquatorialImages.Add(img);
            dataBase.Save();
        }

        public void AddAbnormalImageToPlantType(int plantTypeId, AbnormalImageViewModel abnormalImage)
        {
            Mapper.Reset();
            var plantType = dataBase.PlantTypes.Get(plantTypeId);

            // конфигурирование AutoMapper. Отображение объекта AbnormalImageViewModel на объект AbnormalImage. Тип слева - тип источника, а тип справа - тип назначения
            Mapper.Initialize(cfg => cfg.CreateMap<AbnormalImageViewModel, AbnormalImage>());
            var img = Mapper.Map<AbnormalImage>(abnormalImage);
            plantType.AbnormalImages.Add(img);
            dataBase.Save();
        }

        public void AddEquatorialGrainShapeToPlantType(int plantTypeId, EquatorialGrainShapeViewModel equatorialGrainShape)
        {
            Mapper.Reset();
            var plantType = dataBase.PlantTypes.Get(plantTypeId);

            // конфигурирование AutoMapper. Отображение объекта VAbnormalImageViewModel на объект VAbnormalImage. Тип слева - тип источника, а тип справа - тип назначения
            Mapper.Initialize(cfg => cfg.CreateMap<EquatorialGrainShapeViewModel, EquatorialGrainShape>());
            var shape = Mapper.Map<EquatorialGrainShape>(equatorialGrainShape);
            plantType.EquatorialGrainShapes.Add(shape);
            dataBase.Save();
        }

        public void AddPolarGrainShapeToPlantType(int plantTypeId, PolarGrainShapeViewModel polarGrainShape)
        {
            Mapper.Reset();
            var plantType = dataBase.PlantTypes.Get(plantTypeId);

            // конфигурирование AutoMapper. Отображение объекта PolarGrainShapeViewModel на объект PolarGrainShape. Тип слева - тип источника, а тип справа - тип назначения
            Mapper.Initialize(cfg => cfg.CreateMap<PolarGrainShapeViewModel, PolarGrainShape>());
            var shape = Mapper.Map<PolarGrainShape>(polarGrainShape);
            plantType.PolarGrainShapes.Add(shape);
            dataBase.Save();
        }

        public void RemovePollenColorFromPlantType(int plantTypeId, int pollenColorId)
        {
            throw new NotImplementedException();
        }
        public void RemovePolarImageFromPlantType(int plantTypeId, int polarImageId)
        {
            throw new NotImplementedException();
        }
        public void RemoveEquatorialImageFromPlantType(int plantTypeId, int equatorialImageId)
        {
            throw new NotImplementedException();
        }
        public void RemoveAbnormalImageFromPlantType(int plantTypeId, int abnormalImageId)
        {
            throw new NotImplementedException();
        }
        public void RemoveEquatorialGrainShapeFromPlantType(int plantTypeId, int equatorialGrainShapeId)
        {
            throw new NotImplementedException();
        }
        public void RemovePolarGrainShapeFromPlantType(int plantTypeId, int polarGrainShapeId)
        {
            throw new NotImplementedException();
        }



        public void CreatePlantType(PlantTypeViewModel plantType)
        {
            throw new NotImplementedException();
        }

        public void DeletePlantType(int plantTypeId)
        {
            throw new NotImplementedException();
        }
        public void UpdatePlantType(PlantTypeViewModel plantType)
        {
            throw new NotImplementedException();
        }

        public PlantTypeViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<PlantTypeViewModel> GetAll()
        {
            Mapper.Reset();
            // Конфигурировани AutoMapper
            Mapper.Initialize(cfg => {
                cfg.CreateMap<PlantType, PlantTypeViewModel>();
                cfg.CreateMap<Genus, GenusViewModel>();
                cfg.CreateMap<Family, FamilyViewModel>();
                cfg.CreateMap<Form, FormViewModel>();
                cfg.CreateMap<PolarGrainShape, PolarGrainShapeViewModel>();
                cfg.CreateMap<EquatorialGrainShape, EquatorialGrainShapeViewModel>();

            });

            // Отображение List<PlantType> на ObservableCollection<PlantTypeViewModel>
            var plantType = Mapper.Map<ObservableCollection<PlantTypeViewModel>>(dataBase.PlantTypes.GetAll());
            return plantType;
        }


        public SortedList<int, string> GetSpeciesOfForm(int idForm)
        {
            //Mapper.Reset();
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<PlantType, PlantTypeViewModel>();
            //});
            //var plantType = Mapper.Map<ObservableCollection<PlantTypeViewModel>>(dataBase.PlantTypes.GetSelected(idForm));

            return dataBase.PlantTypes.GetSpeciesOfForm(idForm);
        }

    }
}
