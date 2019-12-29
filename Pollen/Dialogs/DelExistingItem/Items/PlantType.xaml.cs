using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.Services;
using Pollen.BusinessLayer.ViewModels;

namespace Pollen.Dialogs.DelExistingItem.Items
{
    /// <summary>
    /// Interaction logic for PlantType.xaml
    /// </summary>
    public partial class PlantType : Window
    {
        ObservableCollection<PlantTypeViewModel> plantTypes;
        IPlantTypeService plantTypeService;
        public PlantType()
        {
            InitializeComponent();
            plantTypeService = new PlantTypeService("Context");
            plantTypes = plantTypeService.GetAll();
            PlantTypeBox.DataContext = plantTypes;
        }
        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите удалить выбранный вид растения?!!", "ЗАПРОС НА ПОДТВЕРЖДЕНИЕ ДЕЙСТВИЯ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var gen = (PlantTypeViewModel)PlantTypeBox.SelectedItem;
                plantTypeService.DeletePlantType(gen.ID);
                Close();
            }
        }
    }
}
