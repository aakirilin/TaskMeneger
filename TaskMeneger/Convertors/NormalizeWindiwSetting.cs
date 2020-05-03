using System;
using System.Reflection;
using System.Windows;
using TaskMeneger.Properties;

namespace TaskMeneger
{
    public class NormalizeWindiwSetting
    {

        public static PropertyInfo GetProperty(string Name)
        {
            return typeof(Settings).GetProperty(Name);
        }

        public static PropertyInfo Width(string winType)
        {
            return GetProperty(winType + "Width");
        }

        public static PropertyInfo Heigth(string winType)
        {
            return GetProperty(winType + "Heigth");
        }

        public static PropertyInfo Top(string winType)
        {
            return GetProperty(winType + "Top");
        }

        public static PropertyInfo Left(string winType)
        {
            return GetProperty(winType + "Left");
        }

        public static T GetValue<T>(PropertyInfo property)
        {
            return (T)property.GetValue(Settings.Default);
        }

        public static double GetDouble(PropertyInfo property)
        {
            return GetValue<double>(property);
        }

        public static void SetValue(PropertyInfo property, object value)
        {
            property.SetValue(Settings.Default, value);
        }

        public static void Normalize(Type WindowType)
        {
            var top = Top(WindowType.Name);
            var left = Left(WindowType.Name);
            var wigth = Width(WindowType.Name);
            var heigth = Heigth(WindowType.Name);

            var primaryMonitorArea = SystemParameters.WorkArea;
            var wigthWorkArea = primaryMonitorArea.Right;
            var heigthWorkArea = primaryMonitorArea.Bottom;

            if (GetDouble(left) + GetDouble(wigth) >= wigthWorkArea || GetDouble(wigth) < 250)
            {
                SetValue(wigth, wigthWorkArea / 2);
                SetValue(left, wigthWorkArea / 4);
            }

            if (GetDouble(top) + GetDouble(heigth) >= heigthWorkArea || GetDouble(heigth) < 100)
            {
                SetValue(heigth, heigthWorkArea / 2);
                SetValue(top, heigthWorkArea / 4);
            }
        }
    }
}
