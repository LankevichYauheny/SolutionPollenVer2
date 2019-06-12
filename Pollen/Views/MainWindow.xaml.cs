using System.Windows;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;using Pollen.ViewModels;

namespace Pollen.Views
{
    public partial class MainWindow : Window
    {
        ObservableCollection<PlantTypeViewModel> species;
        IPlantTypeService plantTypeService;
        public MainWindow()
        {
            InitializeComponent();
            plantTypeService = new PlantTypeService("Context");
            species = plantTypeService.GetAll();

            TabTree.DataContext = new CheckedListBox(plantTypeService, 1);

            TabBush.DataContext = new CheckedListBox(plantTypeService, 2);

            TabGrass.DataContext = new CheckedListBox(plantTypeService, 3);
            //bushspecies.datacontext = planttypeservice.getspeciesofform(2);
            //grassSpecies.DataContext = plantTypeService.GetSpeciesOfForm(3);
            dataGridTree.ItemsSource = species;
            dataGridBush.ItemsSource = species;
            grassGridBush.ItemsSource = species;

        }

        private void AddNewItem(object sender, RoutedEventArgs e)
        {
            Dialogs.AddNewItem.Add add = new Dialogs.AddNewItem.Add();
            add.ShowDialog();
        }

        private void DelItem(object sender, RoutedEventArgs e)
        {
            Dialogs.DelExistingItem.Del del = new Dialogs.DelExistingItem.Del();
            del.ShowDialog();
        }
    }
}
