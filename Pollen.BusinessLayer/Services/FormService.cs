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
    public class FormService : IFormService
    {
        IUnitOfWork dataBase;
        public FormService(string name)
        {
            dataBase = new EFUnitOfWork(name);
        }


        public void AddFamilyToForm(int formId, FamilyViewModel family)
        {
            Mapper.Reset();
            var form = dataBase.Forms.Get(formId);

            // конфигурирование AutoMapper. Отображение объекта FamilyViewModel на объект Family. Тип слева - тип источника, а тип справа - тип назначения
            Mapper.Initialize(cfg => cfg.CreateMap<FamilyViewModel, Family>());
            var fam = Mapper.Map<Family>(family);
            form.Families.Add(fam);
            dataBase.Save();
        }


        public void RemoveFamilyFromForm(int formId, int familyId)
        {
            throw new NotImplementedException();
        }

        public void CreateForm(FormViewModel formVM)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<FormViewModel, Form>());
            dataBase.Forms.Create(Mapper.Map<Form>(formVM));
            dataBase.Save();
        }

        public void DeleteForm(int formId)
        {
            dataBase.Forms.Delete(formId);
            dataBase.Save();
        }

        public void UpdateForm(FormViewModel formVM)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<FormViewModel, Form>());
            dataBase.Forms.Update(Mapper.Map<Form>(formVM));
            dataBase.Save();
        }

        public FormViewModel Get(int id)
        {
            throw new NotImplementedException();

        }

        public ObservableCollection<FormViewModel> GetAll()
        {
            Mapper.Reset();
            //Конфигурировани AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Form, FormViewModel>();
            });

            //Отображение List<Form> на ObservableCollection< FormViewModel >
            var form = Mapper.Map<ObservableCollection<FormViewModel>>(dataBase.Forms.GetAll());
            return form;
        }
    }
}
