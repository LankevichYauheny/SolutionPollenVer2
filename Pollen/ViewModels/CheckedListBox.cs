using System.ComponentModel;
using Pollen.BusinessLayer.Interfaces;
using System.Collections.Generic;
using Pollen.Models;

namespace Pollen.ViewModels
{
    public class CheckedListBox : INotifyPropertyChanged
    {
        public CheckedListBox(IPlantTypeService plantTypeService, int idForm)
        {
            var i = plantTypeService.GetPlantTypesOfForm(idForm);
            Items = new List<Species>();
            foreach (var temp in i)
            {
                var species = new Species(){Id = temp.Key, Name = temp.Value, IsChecked = false};
                Items.Add(species);
            }
        }
        private List<Species> _items;
        public List<Species> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        private bool _isAllChecked;
        public bool IsAllChecked
        {
            get { return _isAllChecked; }
            set
            {
                _isAllChecked = value;
                if(_isAllChecked)
                {
                    foreach(var temp in Items)
                    {
                        temp.IsChecked = true;
                    }
                }
                else
                {
                    foreach(var temp in Items)
                    {
                        temp.IsChecked = false;
                    }
                }
                OnPropertyChanged("IsAllChecked");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}