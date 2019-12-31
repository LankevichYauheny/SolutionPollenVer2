using System.Windows;
using Pollen.ViewModels;
namespace Pollen.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
        }
        private void AddNewItem(object sender, RoutedEventArgs e)
        {
            var add = new Dialogs.AddNewItem.Add();
            add.ShowDialog();
            _vm.TreesSpecies = _vm.plantTypeService.GetPlantTypes(1);
            _vm.BushesSpecies = _vm.plantTypeService.GetPlantTypes(2);
            _vm.GrassesSpecies = _vm.plantTypeService.GetPlantTypes(3);
        }
        private void DelItem(object sender, RoutedEventArgs e)
        {
            var del = new Dialogs.DelExistingItem.Del();
            del.ShowDialog();
            _vm.TreesSpecies = _vm.plantTypeService.GetPlantTypes(1);
            _vm.BushesSpecies = _vm.plantTypeService.GetPlantTypes(2);
            _vm.GrassesSpecies = _vm.plantTypeService.GetPlantTypes(3);
        }
    }
}
