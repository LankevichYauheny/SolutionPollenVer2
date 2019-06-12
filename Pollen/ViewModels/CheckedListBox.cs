using System.ComponentModel;
using Pollen.BusinessLayer.Interfaces;
using System.Collections.Generic;
using Pollen.Models;

namespace Pollen.ViewModels
{
    class CheckedListBox : INotifyPropertyChanged
    {
        public CheckedListBox(IPlantTypeService plantTypeService, int idForm)
        {
            var i = plantTypeService.GetSpeciesOfForm(idForm);
            Items = new List<Species>();
            foreach (var temp in i)
            {
                Species species = new Species(){Id = temp.Key, Name = temp.Value, IsChecked = false};
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
                if(_isAllChecked == true)
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            if (pceh != null)
            {
                pceh(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

   
























    //class CheckedListBox : INotifyPropertyChanged
    //{

    //    public CheckedListBox(IPlantTypeService plantTypeService, int idForm)
    //    {
    //        species = plantTypeService.GetSpeciesOfForm(idForm);

    //        Items = new CheckableObservableCollection<int, string>();

    //        foreach (var item in species)
    //        {
    //            Items.Add(item.Key, item.Value);
    //        }
    //    }
    //    private SortedList<int, string> species;

    //    private CheckableObservableCollection<int, string> _items;
    //    public CheckableObservableCollection<int, string> Items
    //    {
    //        get { return _items; }
    //        set
    //        {
    //            _items = value;
    //            OnPropertyChanged("Items");
    //        }
    //    }



    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChangedEventHandler pceh = PropertyChanged;
    //        if (pceh != null)
    //        {
    //            pceh(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}





    //public class CheckWrapper<T, U> : INotifyPropertyChanged
    //{
    //    private readonly CheckableObservableCollection<T, U> _parent;
    //    public CheckWrapper(CheckableObservableCollection<T, U> parent)
    //    {
    //        _parent = parent;
    //    }



    //    private T _key;
    //    public T Key
    //    {
    //        get { return _key; }
    //        set
    //        {
    //            _key = value;
    //        }
    //    }

    //    private U _value;
    //    public U Value
    //    {
    //        get { return _value; }
    //        set
    //        {
    //            _value = value;
    //            OnPropertyChanged("Value");
    //        }
    //    }

    //    private bool _isChecked;
    //    public bool IsChecked
    //    {
    //        get { return _isChecked; }
    //        set
    //        {
    //            _isChecked = value;
    //            CheckChanged();
    //            OnPropertyChanged("IsChecked");
    //        }
    //    }

    //    private bool _isAllChecked;
    //    public bool IsAllChecked
    //    {
    //        get { return _isAllChecked; }
    //        set
    //        {
    //            _isAllChecked = value;
    //            CheckChanged();
    //            OnPropertyChanged("IsAllChecked");
    //        }
    //    }

    //    private void CheckChanged()
    //    {
    //        _parent.Refresh();
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChangedEventHandler pceh = PropertyChanged;
    //        if (pceh != null)
    //        {
    //            pceh(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}




    //public class CheckableObservableCollection<T, U> : ObservableCollection<CheckWrapper<T, U>>
    //{
    //    private ListCollectionView _selected;

    //    public CheckableObservableCollection()
    //    {
    //        _selected = new ListCollectionView(this);

    //        _selected.Filter = delegate (object checkObject)
    //        {
    //            return ((CheckWrapper<T, U>)checkObject).IsChecked;
    //        };
    //    }

    //    public void Add(T key, U value)
    //    {
    //        this.Add(new CheckWrapper<T, U>(this) { Key = key, Value = value });
    //    }

    //    public ICollectionView CheckedItems
    //    {
    //        get { return _selected; }
    //    }

    //    internal void Refresh()
    //    {
    //        _selected.Refresh();
    //    }
    //}
}