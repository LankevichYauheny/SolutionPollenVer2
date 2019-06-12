using System.Windows;
using System;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;

namespace Pollen.Dialogs.DelExistingItem.Items
{
    /// Interaction logic for Family.xaml
    public partial class Family : Window
    {
        ObservableCollection<FamilyViewModel> family;
        IFamilyService familyService;
        public Family()
        {
            InitializeComponent();
            familyService = new FamilyService("Context");
            family = familyService.GetAll();
            FamilyBox.DataContext = family;
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить выбранное семейство растений?!!", "ЗАПРОС НА ПОДТВЕРЖДЕНИЕ ДЕЙСТВИЯ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var gen = (FamilyViewModel)FamilyBox.SelectedItem;
                familyService.DeleteFamily(gen.ID);
                Close();
            }
        }
    }
}
