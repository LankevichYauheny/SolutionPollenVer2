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

    public partial class Del
    {

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
