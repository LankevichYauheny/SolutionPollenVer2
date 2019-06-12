using System.Windows;
using System;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;

namespace Pollen.Dialogs.DelExistingItem.Items
{

    public partial class Genus : Window
    {
        ObservableCollection<GenusViewModel> genus;
        IGenusService genusService;
        public Genus()
        {
            InitializeComponent();
            genusService = new GenusService("Context");
            genus = genusService.GetAll();
            GenusBox.DataContext = genus;
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            
            if (MessageBox.Show("Вы действительно хотите удалить выбранный род растений?!!", "ЗАПРОС НА ПОДТВЕРЖДЕНИЕ ДЕЙСТВИЯ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var gen = (GenusViewModel)GenusBox.SelectedItem;
                genusService.DeleteGenus(gen.ID);
                Close();
            }
        }
    }
}
