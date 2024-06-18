using Langueage;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using JsonSerialize;
using System.Diagnostics;


namespace Libraries
{
    public partial class MainWindow : Window
    {
        private bool _isEnglish = true;

        public MainWindow()
        {
            InitializeComponent();
            LoadLocalization();


            LbConclusion.Items.Add(new Case { NameEng = "Do something" });
            LbConclusion.Items.Add(new Case { NameEng = "Do something" });
            LbConclusion.Items.Add(new Case { NameEng = "Do something" });
            LbConclusion.Items.Add(new Case { NameEng = "Do something" });
            LbConclusion.Items.Add(new Case { NameEng = "Do something" });

            LbConclusion.DisplayMemberPath = "NameEng";
        }

        private void BtAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (LbConclusion.SelectedItem != null)
            {
                LbConclusion.Items.Remove(LbConclusion.SelectedItem);
            }
        }

        private void BtImport_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var items = json.Deserialize<Case>(openFileDialog.FileName);
                    foreach (var item in items)
                    {
                        LbConclusion.Items.Add(item);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void BtExport_OnClick(object sender, RoutedEventArgs e)
        {
            var items = new List<Case>();
            foreach (var item in LbConclusion.Items)
            {
                if (item is Case @case)
                {
                    items.Add(@case);
                }
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    json.Serialize(items, saveFileDialog.FileName);
                    MessageBox.Show("WP");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void LoadLocalization()
        {
            LoadL.AddLocale("en", new ResourceDictionary
            {
                Source = new Uri("C:/Users/kira0/RiderProjects/LibrariesProject/Language/Resources/String.en.xaml")
            });
            LoadL.AddLocale("ru", new ResourceDictionary
            {
                Source = new Uri("C:/Users/kira0/RiderProjects/LibrariesProject/Language/Resources/String.rus.xaml")
            });

            LoadL.ChangeLocale("ru");
        }
        private void BtChangeLang_OnClick(object sender, RoutedEventArgs e)
        {
            _isEnglish = !_isEnglish;
            LoadL.ChangeLocale(_isEnglish ? "en" : "ru");
        }
    }
}
