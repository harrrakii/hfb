using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Langueage
{
    public static class LoadL
    {
        private static readonly Dictionary<string, ResourceDictionary> Locales = new Dictionary<string, ResourceDictionary>();

        public static void AddLocale(string name, ResourceDictionary resourceDictionary)
        {
            Locales[name] = resourceDictionary;
        }

        public static void ChangeLocale(string name)
        {
            if (Locales.TryGetValue(name, out var resourceDictionary))
            {
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
        }
    }

}
