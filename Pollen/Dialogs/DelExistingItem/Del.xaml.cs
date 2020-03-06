using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Security.Permissions;
using Pollen.Interfaces;
using Pollen.Views;

namespace Pollen.Dialogs.DelExistingItem
{
    [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
    public partial class Del : IView
    {
        #region IView Members

        public IViewModel ViewModel
        {
            get
            {
                return DataContext as IViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        #endregion

        public Del()
        {
            InitializeComponent();
        }

        private void DelFamily(object sender, RoutedEventArgs e)
        {
            var dialog = new Items.Family();
            dialog.ShowDialog();
        }

        private void DelGenus(object sender, RoutedEventArgs e)
        {

            var dialog = new Items.Genus();
            dialog.ShowDialog();
        }

        private void DelSpecies(object sender, RoutedEventArgs e)
        {
            var dialog = new Items.PlantType();
            dialog.ShowDialog();
        }
    }
}
