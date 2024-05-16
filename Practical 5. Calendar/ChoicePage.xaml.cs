using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Practical_5._Calendar
{
    /// <summary>
    /// Логика взаимодействия для ChoicePage.xaml
    /// </summary>
    public partial class ChoicePage : Page
    {
        bool found = false;

        List<ChoicePoint> choice_points_list = new List<ChoicePoint>();

        public List<UserChoicePerDay> userChoicesPerAllDays = De_Serealize_.Deserialize<UserChoicePerDay>(way);
        public static string way = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Choices-Data";
        public ChoicePage()
        {
            InitializeComponent();
        }

        private void Choice_Page_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeListOfChoices();
        }
        private void InitializeListOfChoices()
        {
            choice_points_list.Clear();

            choice_points_list.Add(new ChoicePoint { ChoiceName = "Ебнуть пивка", Icon = (new Uri("pivo.jpg", UriKind.Relative)) });
            choice_points_list.Add(new ChoicePoint { ChoiceName = "Хряпнуть водочки", Icon = (new Uri("vodka.png", UriKind.Relative)) });
            choice_points_list.Add(new ChoicePoint { ChoiceName = "Кровавая мери, которую Скорогудаева гововит в шарике", Icon =  (new Uri("scorogudaeva.png", UriKind.Relative)) });
            choice_points_list.Add(new ChoicePoint { ChoiceName = "Запить яблочный виски огуречным рассолом", Icon =  (new Uri("viskey.png", UriKind.Relative)) });
            choice_points_list.Add(new ChoicePoint { ChoiceName = "Пригубить винца", Icon =  (new Uri("vino.png", UriKind.Relative)) });
            choice_points_list.Add(new ChoicePoint { ChoiceName = "Закусить лимончиком", Icon =  (new Uri("limon.png", UriKind.Relative)) });

            foreach (UserChoicePerDay item in userChoicesPerAllDays)
            {
                if (item.Date == MainWindow.selectedDate)
                {
                    foreach (ChoicePoint item2 in choice_points_list)
                    {
                        bool isChoiceSelected = item.userChoice_list.Exists(c => c.ChoiceName == item2.ChoiceName && c.isSelected == true);
                        item2.isSelected = isChoiceSelected;
                    }
                }
            }
            ListBox.ItemsSource = choice_points_list;
        }

        private void Save_BTN_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < userChoicesPerAllDays.Count; i++)
            {
                if (userChoicesPerAllDays[i].Date == MainWindow.selectedDate)
                {
                    userChoicesPerAllDays[i].userChoice_list = choice_points_list; //здесь будем менять содержимое только листа
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                userChoicesPerAllDays.Add(new UserChoicePerDay { Date = MainWindow.selectedDate, userChoice_list = choice_points_list });
            }

            De_Serealize_.Serialize(userChoicesPerAllDays, way);
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { ListBox.SelectedIndex = -1; }
    }
}
