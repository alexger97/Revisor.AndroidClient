 
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Revisor.View.Converter
{
    class VisabilityImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                if ((value as string).Length > 0&& (value as string)!="")
                {
                    if (System.Convert.ToInt32(parameter) == 1) return true;
                    
                }
                else
                {
                    if (System.Convert.ToInt32(parameter) == 1) return false;  
                }
            }
            return false;
              
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
