using System.Windows;
using Pollen.ViewModels;
namespace Pollen.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            DataContext = vm;
        }
        private void AddNewItem(object sender, RoutedEventArgs e)
        {
            var add = new Dialogs.AddNewItem.Add();
            add.ShowDialog();
            vm.Species = vm.plantTypeService.GetAll();
            
        }
        private void DelItem(object sender, RoutedEventArgs e)
        {
            var del = new Dialogs.DelExistingItem.Del();
            del.ShowDialog();
            vm.Species = vm.plantTypeService.GetAll();
        }
    }
}
