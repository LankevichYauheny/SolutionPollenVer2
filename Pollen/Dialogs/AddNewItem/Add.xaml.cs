using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;
using System.Security.Permissions;
using Pollen.Interfaces;
using Pollen.Views;

namespace Pollen.Dialogs.AddNewItem
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
    public partial class Add : IView
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

        public Add()
        {
            InitializeComponent();
        }

        private void AddFamily(object sender, RoutedEventArgs e)
        {
            var dialog = new Item.Family();
            var result = dialog.ShowDialog();
        }

        private void AddGenus(object sender, RoutedEventArgs e)
        {
            var genus = new Item.Genus();
            var result = genus.ShowDialog();
        }

        private void AddSpecies(object sender, RoutedEventArgs e)
        {
            Item.Species species = new Item.Species();
            species.ShowDialog();
        }
    }
}
