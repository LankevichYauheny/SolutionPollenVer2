using System.Windows;
using Pollen.ViewModels;
using Pollen.Interfaces;

namespace Pollen.Views
{
    public partial class MainWindow : Window, IView
    {
        public IViewModel ViewModel
        {
            get => DataContext as IViewModel;
            set => DataContext = value;
        }

        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            DataContext = vm;
        }
    }
}
