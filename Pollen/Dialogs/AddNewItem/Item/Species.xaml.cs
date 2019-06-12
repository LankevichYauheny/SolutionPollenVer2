using System;
using System.Windows;
using System.Windows.Media;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;
using Microsoft.Win32;
namespace Pollen.Dialogs.AddNewItem.Item
{
    public partial class Species : Window
    {
        ObservableCollection<GenusViewModel> genus;
        IGenusService genusService;
        public Species()
        {
            InitializeComponent();
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
                        var plantTypeVM = new PlantTypeViewModel();
                        plantTypeVM.NameEN = SpeciesNameEN.Text;
                        plantTypeVM.NameRU = SpeciesNameRU.Text;
                        var genus = (GenusViewModel)GenusName.SelectedItem;
                        genus.PlantTypes.Add(plantTypeVM);
                        genusService.AddPlantTypeToGenus(genus.ID, plantTypeVM);
                        genus.PlantTypes.Add(plantTypeVM);
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
                var path = dlg.FileName;
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
                var path = dlg.FileName;
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
                var path = dlg.FileName;
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
                var path = dlg.FileName;
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
                var path = dlg.FileName;
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
                var path = dlg.FileName;
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
                var path = dlg.FileName;
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
                var path = dlg.FileName;
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
                var path = dlg.FileName;
                AbnormalImage3.Background = Brushes.Green;
            }
        }
    }
}
