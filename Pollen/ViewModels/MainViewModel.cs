using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.Services;
using Pollen.BusinessLayer.ViewModels;
using Pollen.Infrastructure;
using Pollen.Interfaces;

namespace Pollen.ViewModels
{
    public class MainViewModel : ViewModelBase, IViewModel
    {
        public IPlantTypeService _plantTypeService;

        public MainViewModel()
        {
            AddNewItemCommand = new RelayCommand(AddNewItem, null);
            DelItemCommand = new RelayCommand(DelItem, null);
            UpdateItemCommand = new RelayCommand(UpdateItem, null);

            _plantTypeService = new PlantTypeService("Context");
            InitializeGrids();
        }

        private void InitializeGrids()
        {
            Tree = new CheckedListBox(_plantTypeService, 1);
            Bush = new CheckedListBox(_plantTypeService, 2);
            Grass = new CheckedListBox(_plantTypeService, 3);


            TreesSpecies = _plantTypeService.GetPlantTypes(1);
            //var x = TreesSpecies.FirstOrDefault(s => s != null)?.PolarImages.FirstOrDefault(i => i !=null).FileContents;
            BushesSpecies = _plantTypeService.GetPlantTypes(2);
            GrassesSpecies = _plantTypeService.GetPlantTypes(3);
        }

        private CheckedListBox _tree;

        public CheckedListBox Tree
        {
            get { return _tree; }
            set
            {
                _tree = value;
                OnPropertyChanged("Tree");
            }
        }

        private CheckedListBox _bush;

        public CheckedListBox Bush
        {
            get { return _bush; }
            set
            {
                _bush = value;
                OnPropertyChanged("Bush");
            }
        }

        private CheckedListBox _grass;

        public CheckedListBox Grass
        {
            get { return _grass; }
            set
            {
                _grass = value;
                OnPropertyChanged("Grass");
            }
        }

        private ObservableCollection<PlantTypeViewModel> _treesSpecies;

        public ObservableCollection<PlantTypeViewModel> TreesSpecies
        {
            get { return _treesSpecies; }
            set
            {
                _treesSpecies = value;
                OnPropertyChanged("TreesSpecies");
            }
        }

        private ObservableCollection<PlantTypeViewModel> _bushesSpecies;

        public ObservableCollection<PlantTypeViewModel> BushesSpecies
        {
            get { return _bushesSpecies; }
            set
            {
                _bushesSpecies = value;
                OnPropertyChanged("BushesSpecies");
            }
        }

        private ObservableCollection<PlantTypeViewModel> _grassesSpecies;

        public ObservableCollection<PlantTypeViewModel> GrassesSpecies
        {
            get { return _grassesSpecies; }
            set
            {
                _grassesSpecies = value;
                OnPropertyChanged("GrassesSpecies");
            }
        }

        #region Commands
        public RelayCommand AddNewItemCommand { get; }

        public RelayCommand DelItemCommand { get; }

        public RelayCommand UpdateItemCommand { get; }
        #endregion

        private void AddNewItem(object parameter)
        {
            try
            {
                var add = new Dialogs.AddNewItem.Add();
                add.ShowDialog();
                TreesSpecies = _plantTypeService.GetPlantTypes(1);
                BushesSpecies = _plantTypeService.GetPlantTypes(2);
                GrassesSpecies = _plantTypeService.GetPlantTypes(3);
            }
            catch (SecurityException)
            {
            }
        }

        private void DelItem(object parameter)
        {
            try
            {
                var del = new Dialogs.DelExistingItem.Del();
                del.ShowDialog();
                TreesSpecies = _plantTypeService.GetPlantTypes(1);
                BushesSpecies = _plantTypeService.GetPlantTypes(2);
                GrassesSpecies = _plantTypeService.GetPlantTypes(3);
            }
            catch (SecurityException)
            {
            }
        }       
        
        private void UpdateItem(object parameter)
        {
            try
            {
                var del = new Dialogs.DelExistingItem.Del();
                del.ShowDialog();
                TreesSpecies = _plantTypeService.GetPlantTypes(1);
                BushesSpecies = _plantTypeService.GetPlantTypes(2);
                GrassesSpecies = _plantTypeService.GetPlantTypes(3);
            }
            catch (SecurityException)
            {
            }
        }
    }
}

