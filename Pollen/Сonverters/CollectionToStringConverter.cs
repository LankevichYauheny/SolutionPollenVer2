using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Pollen.BusinessLayer.ViewModels;

namespace Pollen.Сonverters
{
    class CollectionToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = null;
            if (value is ObservableCollection<PolarGrainShapeViewModel> polarGrainShapes)
            {
                foreach (var polarGrainShape in polarGrainShapes)
                {
                    if (result != null)
                        result += ", ";
                    result += polarGrainShape.Name;
                }
            }
            if (value is ObservableCollection<EquatorialGrainShapeViewModel> equatorialGrainShapes)
            {
                foreach (var equatorialGrainShape in equatorialGrainShapes)
                {
                    if (result != null)
                        result += ", ";
                    result += equatorialGrainShape.Name;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}