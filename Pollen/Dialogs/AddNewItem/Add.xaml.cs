using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;

namespace Pollen.Dialogs.AddNewItem
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Add : Window
    {
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
