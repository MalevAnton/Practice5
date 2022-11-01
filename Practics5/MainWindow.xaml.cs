using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Xml.Linq;

namespace Practics5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CMmonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RBzodiac_Checked(object sender, RoutedEventArgs e)
        {
            TBbirthday.Text = "";
            ZodiacStackPanel.Visibility = Visibility.Collapsed;
            ZodiacStackPanel.Visibility = Visibility.Visible;
            CMmonth.Visibility = Visibility.Visible;
            TBname.Text = "Введите дату своего рождения";

            // RBeast.IsChecked = false;

        }

        private void RBeast_Checked(object sender, RoutedEventArgs e)
        {
            TBbirthday.Text = "";
            ZodiacStackPanel.Visibility = Visibility.Visible;
            CMmonth.Visibility = Visibility.Collapsed;
            Eastzodiac.Visibility = Visibility.Visible;
            CMmonth.Visibility = Visibility.Collapsed;
            TBname.Text = "Введите год своего рождения";


        }

        private void TBbirthday_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (TBbirthday.Text != "")
            {
                try
                {
                    int s = Convert.ToInt32(TBbirthday.Text);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Вы ввели символ! Пожалуйста,введите цифрy");
                }
            }


        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)RBzodiac.IsChecked)
                {
                    int day = DateTime.DaysInMonth(DateTime.Now.Year, CMmonth.SelectedIndex + 1);
                    int[] date = new int[2];
                    date[0] = Convert.ToInt32(TBbirthday.Text);
                    date[1] = Convert.ToInt32(CMmonth.SelectedIndex + 1);


                    if (date[0] > day || date[1] > 12)
                    {

                        MessageBox.Show("Неверная дата!");

                    }
                    else
                    {
                        switch (date[1])
                        {
                            case 1: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 20 ? "Козерог" : "Водолей")); break;
                            // слева правда ложь, справа ложь
                            case 2: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 19 ? "Водолей" : "Рыбы")); break;
                            case 3: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 20 ? "Рыбы" : "Овен")); break;
                            case 4: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 20 ? "Овен" : "Телец")); break;
                            case 5: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 21 ? "Телец" : "Близнецы")); break;
                            case 6: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 21 ? "Близнецы" : "Рак")); break;
                            case 7: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 22 ? "Рак" : "Лев")); break;
                            case 8: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 23 ? "Лев" : "Дева")); break;
                            case 9: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 23 ? "Дева" : "Весы")); break;
                            case 10: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 23 ? "Весы" : "Скорпион")); break;
                            case 11: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 22 ? "Скорпион" : "Стрелец")); break;
                            case 12: MessageBox.Show("Ваш знак зодиака - " + (date[0] <= 23 ? "Стрелец" : "Козерог")); break;
                        }
                    }

                }
                else
                {
                    int date;
                    date = Convert.ToInt32(TBbirthday.Text);
                    date %= 12;
                    date++;

                    switch (date)
                    {
                        case 1: MessageBox.Show("Обезьяна"); break;
                        case 2: MessageBox.Show("Петух"); break;
                        case 3: MessageBox.Show("Собака"); break;
                        case 4: MessageBox.Show("Кабан"); break;
                        case 5: MessageBox.Show("Крыса"); break;
                        case 6: MessageBox.Show("Бык"); break;
                        case 7: MessageBox.Show("Тигр"); break;
                        case 8: MessageBox.Show("Кролик"); break;
                        case 9: MessageBox.Show("Дракон"); break;
                        case 10: MessageBox.Show("Змея"); break;
                        case 11: MessageBox.Show("Лошадь"); break;
                        case 12: MessageBox.Show("Овца"); break;

                    }



                }
            }
            catch
            {

                MessageBox.Show("Возможно ничего не выбрано или что-то не введено. Попробуйте еще раз.");
            }




        }
    }
}
