using System.Collections.ObjectModel;
using System.ComponentModel;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.Services;
using Pollen.BusinessLayer.ViewModels;

namespace Pollen.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public IPlantTypeService plantTypeService;
        public MainViewModel()
        {
            plantTypeService = new PlantTypeService("Context");
            InitializeGrids();
        }

        private void InitializeGrids()
        {
            Tree = new CheckedListBox(plantTypeService, 1);
            Bush = new CheckedListBox(plantTypeService, 2);
            Grass = new CheckedListBox(plantTypeService, 3);
            Species = plantTypeService.GetAll();
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

        private ObservableCollection<PlantTypeViewModel> _species;
        public ObservableCollection<PlantTypeViewModel> Species
        {
            get { return _species; }
            set
            {
                _species = value;
                OnPropertyChanged("Species");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

