using System.Windows;
using System;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;

namespace Pollen.Dialogs.AddNewItem.Item
{
    public partial class Family : Window
    {
        ObservableCollection<FormViewModel> form;
        IFormService formService;
        public Family()
        {
            InitializeComponent();
            formService = new FormService("Context");
            form = formService.GetAll();
            FormName.DataContext = form;
        }
        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (FamilyNameEN.Text == "" || FamilyNameRU.Text == "")
            {
                MessageBox.Show("Заполните форму", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string strRU = FamilyNameRU.Text.ToLower();
                string strEN = FamilyNameEN.Text.ToLower();
                bool RUisOK = true;
                bool ENisOK = true;

                foreach (char b in strEN) 
                {
                    if (b >= 'а' && b <= 'я') 
                    {
                        MessageBox.Show("Поле \"ЛАТИНСКОЕ НАЗВАНИЕ\" должно содержать только литинские символы!!!", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                        ENisOK = false;
                        break;
                    }
                }
                foreach (char a in strRU)
                {
                    if (a >= 'a' && a <= 'z')
                    {
                        MessageBox.Show("Поле \"РУССКОЕ НАЗВАНИЕ\" должно содержать только символы кириллицы!!!", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                        RUisOK = false;
                        break;
                    }
                }
                if (RUisOK && ENisOK)
                {
                    try
                    {
                        var familyVM = new FamilyViewModel();
                        familyVM.NameEN = FamilyNameEN.Text;
                        familyVM.NameRU = FamilyNameRU.Text;
                        var form = (FormViewModel)FormName.SelectedItem;
                        form.Families.Add(familyVM);
                        formService.AddFamilyToForm(form.ID, familyVM);
                        form.Families.Add(familyVM);
                        Close();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show("Проверьте \"ЛАТИНСКОЕ НАЗВАНИЕ\" и \"РУССКОЕ НАЗВАНИЕ\" возможно они уже присутствуют в базе данных!!!", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.Message, "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
    }
}
