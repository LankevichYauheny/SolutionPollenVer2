using System;
using System.Windows;
using System.Windows.Media;
using Pollen.BusinessLayer.Interfaces;
using Pollen.BusinessLayer.ViewModels;
using Pollen.BusinessLayer.Services;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

namespace Pollen.Dialogs.AddNewItem.Item
{
    public partial class Species : Window
    {
        ObservableCollection<GenusViewModel> genus;
        IGenusService genusService;
        private PlantTypeViewModel _plantTypeVM;
        private List<string> _pathsToPolarImages;
        private List<string> _pathsToEquatorialImages;
        private List<string> _pathsToAbnormalImages;
        
        public Species()
        {
            InitializeComponent();
            _plantTypeVM = new PlantTypeViewModel()
            {
                PolarImages = new ObservableCollection<PolarImageViewModel>(),
                AbnormalImages = new ObservableCollection<AbnormalImageViewModel>(),
                EquatorialImages = new ObservableCollection<EquatorialImageViewModel>(),
                PolarGrainShapes = new ObservableCollection<PolarGrainShapeViewModel>(),
                EquatorialGrainShapes = new ObservableCollection<EquatorialGrainShapeViewModel>()
            };
            _pathsToPolarImages = new List<string>();
            _pathsToEquatorialImages = new List<string>();
            _pathsToAbnormalImages = new List<string>();
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
                        _plantTypeVM.AdditionalNameRU = AdditionalNameRU.Text;
                        _plantTypeVM.DustingTime = DustingTime.Text;
                        _plantTypeVM.PollenSculpture = PollenSculpture.Text;
                        _plantTypeVM.ApertureStructure = ApertureStructure.Text;
                        _plantTypeVM.ApertureNumber = Convert.ToInt32(ApertureNumber.Text);
                        _plantTypeVM.AperturePosition = AperturePosition.Text;
                        _plantTypeVM.ApertureType = ApertureType.Text;
                        _plantTypeVM.PollenFeatures = PollenFeatures.Text;
                        _plantTypeVM.PollenPolarMinSize = Convert.ToDecimal(PollenPolarMinSize.Text);
                        _plantTypeVM.PollenPolarMaxSize = Convert.ToDecimal(PollenPolarMaxSize.Text);
                        _plantTypeVM.PollenEquatorialMinSize = Convert.ToDecimal(PollenEquatorialMinSize.Text);
                        _plantTypeVM.PollenEquatorialMaxSize = Convert.ToDecimal(PollenEquatorialMaxSize.Text);
                        _plantTypeVM.ExinePolarMinThickness = Convert.ToDecimal(ExinePolarMin.Text);
                        _plantTypeVM.ExinePolarMaxThickness = Convert.ToDecimal(ExinePolarMax.Text);
                        _plantTypeVM.ExineEquatorialMinThickness = Convert.ToDecimal(ExineEquatorialMin.Text);
                        _plantTypeVM.ExineEquatorialMaxThickness = Convert.ToDecimal(ExineEquatorialMax.Text);
                        _plantTypeVM.PolarGrainShapes.Add(new PolarGrainShapeViewModel() {Name = PolarGrainShape.Text});
                        _plantTypeVM.EquatorialGrainShapes.Add(new EquatorialGrainShapeViewModel() {Name = EquatorialGrainShape.Text});
                        _plantTypeVM.PollenColor = PollenColor.Text;



                        foreach (var path in _pathsToPolarImages)
                        {
                            var polarImageViewModel = new PolarImageViewModel() {FileID = new Guid()};
                            using (FileStream fstream = File.OpenRead(path))
                            {
                                // преобразуем строку в байты
                                byte[] array = new byte[fstream.Length];
                                // считываем данные
                                fstream.Read(array, 0, array.Length);
                                polarImageViewModel.FileID = Guid.NewGuid();
                                polarImageViewModel.FileContents = array;
                            }
                            _plantTypeVM.PolarImages.Add(polarImageViewModel);
                        }

                        foreach (var path in _pathsToEquatorialImages)
                        {
                            var equatorialImageViewModel = new EquatorialImageViewModel() { FileID = new Guid() };
                            using (FileStream fstream = File.OpenRead(path))
                            {
                                // преобразуем строку в байты
                                byte[] array = new byte[fstream.Length];
                                // считываем данные
                                fstream.Read(array, 0, array.Length);
                                equatorialImageViewModel.FileID = Guid.NewGuid();
                                equatorialImageViewModel.FileContents = array;
                            }
                            _plantTypeVM.EquatorialImages.Add(equatorialImageViewModel);
                        }

                        foreach (var path in _pathsToAbnormalImages)
                        {
                            var abnormalImageViewModel = new AbnormalImageViewModel() { FileID = new Guid() };
                            using (FileStream fstream = File.OpenRead(path))
                            {
                                // преобразуем строку в байты
                                byte[] array = new byte[fstream.Length];
                                // считываем данные
                                fstream.Read(array, 0, array.Length);
                                abnormalImageViewModel.FileID = Guid.NewGuid();
                                abnormalImageViewModel.FileContents = array;
                            }
                            _plantTypeVM.AbnormalImages.Add(abnormalImageViewModel);
                        }





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
                _pathsToPolarImages.Add(dlg.FileName);
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
                _pathsToPolarImages.Add(dlg.FileName);
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
                _pathsToPolarImages.Add(dlg.FileName);
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
                _pathsToEquatorialImages.Add(dlg.FileName);
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
                _pathsToEquatorialImages.Add(dlg.FileName);
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
                _pathsToEquatorialImages.Add(dlg.FileName);
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
                _pathsToAbnormalImages.Add(dlg.FileName);
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
                _pathsToAbnormalImages.Add(dlg.FileName);
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
                _pathsToAbnormalImages.Add(dlg.FileName);
                AbnormalImage3.Background = Brushes.Green;
            }
        }
    }
}
