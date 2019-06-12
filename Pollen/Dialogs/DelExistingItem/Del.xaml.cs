using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;

namespace Pollen.Dialogs.DelExistingItem
{

    public partial class Del : Window
    {

        public Del()
        {
            InitializeComponent();
        }

        private void DelFamily(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.DelExistingItem.Items.Family();
            dialog.ShowDialog();
        }

        private void DelGenus(object sender, RoutedEventArgs e)
        {

            var diglog = new Dialogs.DelExistingItem.Items.Genus();
            diglog.ShowDialog();
        }

        private void DelSpecies(object sender, RoutedEventArgs e)
        {

        }
    }
}
