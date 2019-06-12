using System.Windows;
using System;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;

namespace Pollen.Dialogs.AddNewItem.Item
{
    public partial class Genus : Window
    {
        ObservableCollection<FamilyViewModel> family;
        IFamilyService familyService;
        public Genus()
        {
            InitializeComponent();
            familyService = new FamilyService("Context");
            family = familyService.GetAll();
            FamilyName.DataContext = family;
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (GenusNameEN.Text == "" || GenusNameRU.Text == "")
            {
                MessageBox.Show("Заполните форму", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string strRU = GenusNameRU.Text.ToLower();
                string strEN = GenusNameEN.Text.ToLower();
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
                        var genusVM = new GenusViewModel();
                        genusVM.NameEN = GenusNameEN.Text;
                        genusVM.NameRU = GenusNameRU.Text;
                        var fam = (FamilyViewModel)FamilyName.SelectedItem;
                        fam.Genera.Add(genusVM);
                        familyService.AddGenusToFamily(fam.ID, genusVM);
                        fam.Genera.Add(genusVM);
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
