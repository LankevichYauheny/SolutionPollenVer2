using System;
using System.ComponentModel;

namespace Pollen.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propetryName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if(handler != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetryName));
            }
        }

        public void Dispose()
        {
            OnDispose();
        }

        protected virtual void OnDispose()
        {
        }
    }
}
