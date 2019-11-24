using System;
using System.Windows;
using System.Windows.Media;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Collections.Generic;
namespace Pollen.Dialogs.AddNewItem.Item
{
    public partial class Species : Window
    {
        ObservableCollection<GenusViewModel> genus;
        IGenusService genusService;
        private PlantTypeViewModel _plantTypeVM;
        private Dictionary<int, string> _pathsToPolarImages;
        private Dictionary<int, string> _pathsToEquatorialImages;
        private Dictionary<int, string> _pathsToAbnormalImages;
        
        public Species()
        {
            InitializeComponent();
            _plantTypeVM = new PlantTypeViewModel();
            _pathsToPolarImages = new Dictionary<int, string>();
            _pathsToEquatorialImages = new Dictionary<int, string> ();
            _pathsToAbnormalImages = new Dictionary<int, string>();
            genusService = new GenusService("Context");
            genus = genusService.GetAll();
            GenusName.DataContext = genus;

        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (SpeciesNameEN.Text == "" || SpeciesNameRU.Text == "" || DustingTime.Text == "" || PollenSculpture.Text == ""
                || ApertureStructure.Text == "" || ApertureNumber.Text == "" || AperturePosition.Text == "" || ApertureType.Text == ""
                || PollenPolarMinSize.Text == "" || PollenPolarMaxSize.Text == "" || PollenEquatorialMinSize.Text == "" || PollenEquatorialMaxSize.Text == ""
                || ExinePolarMin.Text == "" || ExinePolarMax.Text == "" || ExineEquatorialMin.Text == "" || ExineEquatorialMax.Text == "")
            {
                MessageBox.Show("Заполните форму", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string strRU = SpeciesNameRU.Text.ToLower();
                string strEN = SpeciesNameEN.Text.ToLower();
                bool RUisOK = true;
                bool ENisOK = true;

                foreach (char b in strEN)
                {
                    if (b >= 'а' && b <= 'я')
                    {
                        MessageBox.Show("Поле \"ЛАТИНСКОЕ НАЗВАНИЕ\" должно содержать только литинские символы!!!", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                        ENisOK = false;
                        break;
                    }
                }
                foreach (char a in strRU)
                {
                    if (a >= 'a' && a <= 'z')
                    {
                        MessageBox.Show("Поле \"РУССКОЕ НАЗВАНИЕ\" должно содержать только символы кириллицы!!!", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                        RUisOK = false;
                        break;
                    }
                }
                if (RUisOK && ENisOK)
                {
                    try
                    {
                        _plantTypeVM.NameEN = SpeciesNameEN.Text;
                        _plantTypeVM.NameRU = SpeciesNameRU.Text;
                        //_plantTypeVM.PolarImages.Add(_polarImage);
                        var genus = (GenusViewModel)GenusName.SelectedItem;
                        genus.PlantTypes.Add(_plantTypeVM);
                        genusService.AddPlantTypeToGenus(genus.ID, _plantTypeVM);
                        genus.PlantTypes.Add(_plantTypeVM);
                        Close();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show("Проверьте \"ЛАТИНСКОЕ НАЗВАНИЕ\" и \"РУССКОЕ НАЗВАНИЕ\" возможно они уже присутствуют в базе данных!!!", "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.Message, "ПРЕДУПРЕЖДЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        private void buttonPolarImage1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                var dlg1 = dlg.
                _pathsToPolarImages.Add(1, dlg.FileName);
                PolarImage1.Background = Brushes.Green;
            }
        }

        private void buttonPolarImage2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                _pathsToPolarImages.Add(2, dlg.FileName);
                PolarImage2.Background = Brushes.Green;
            }
        }

        private void buttonPolarImage3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                _pathsToPolarImages.Add(3, dlg.FileName);
                PolarImage3.Background = Brushes.Green;
            }
        }

        private void buttonEquatorialImage1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                _pathsToEquatorialImages.Add(1, dlg.FileName);
                EquatorialImage1.Background = Brushes.Green;
            }
        }

        private void buttonEquatorialImage2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                _pathsToEquatorialImages.Add(2, dlg.FileName);
                EquatorialImage2.Background = Brushes.Green;
            }
        }

        private void buttonEquatorialImage3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                _pathsToEquatorialImages.Add(3, dlg.FileName);
                EquatorialImage3.Background = Brushes.Green;
            }
        }

        private void buttonAbnormalImage1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                _pathsToAbnormalImages.Add(1, dlg.FileName);
                AbnormalImage1.Background = Brushes.Green;
            }
        }

        private void buttonAbnormalImage2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                _pathsToAbnormalImages.Add(2, dlg.FileName);
                AbnormalImage2.Background = Brushes.Green;
            }
        }

        private void buttonAbnormalImage3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                FileName = "Изображение",
                Filter = "Все изобажения|*.bmp; *.dib; *.jpg; *.jpeg; *.jpe; *.jfif; *.tif; *.tiff; *.gif|Точечные рисунки|*.bmp;*.dib|JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|TIF|*.tif;*.tiff|GIF|*.gif" // Filter files by extension
            };

            if (dlg.ShowDialog() == true)
            {
                _pathsToAbnormalImages.Add(3, dlg.FileName);
                AbnormalImage3.Background = Brushes.Green;
            }
        }
    }
}
