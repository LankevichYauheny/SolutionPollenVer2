using System.Windows;
using Pollen.Interfaces;

namespace Pollen.Views
{
    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }

        void Show();
    }

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IView
    {
        public LoginWindow(AuthenticationViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        #region IView Members
        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }
        #endregion
    }
}
