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
using Registration;
using Registration.Model;
using System.Data.Entity;
using System.Reflection;

namespace PR3._2_Koshelevskaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        private int countUnsuccessful = 0; // Количество неверных попыток входа
        public Autho()
        {
            InitializeComponent();

            txtboxCaptcha.Visibility = Visibility.Hidden; // Скрывыем надпись и
            txtBlokCaptcha.Visibility = Visibility.Hidden; //поле для ввода капчи
            panelCaptcha.Visibility = Visibility.Hidden;
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client()); //Переход на страницу неавторизованного пользователя
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtbLogin.Text.Trim(); // Объявляем переменную, в которую будет записываться значения с TextBlock`а логина
            string password = txtPassword.Text.Trim(); // Объявляем переменную, в которую будет записываться значения с TextBlock`а пароля

            Avtorizaciya user = new Avtorizaciya(); // создаем пустой обьект авторизации пользователя

            user = Helper.GetContext().Avtorizaciya.Where(p => p.Login == login && p.Parol == password).FirstOrDefault(); // Условие на нахождение пользователя с введенными логином и паролем
            int userCount = Helper.GetContext().Avtorizaciya.Where(p => p.Login == login && p.Parol == password).Count(); // Находим количество пользователей

            if (countUnsuccessful < 1)
            {
                if (userCount > 0)  // если количество пользователей с введеными данными более 0, 
                {
                    MessageBox.Show("Вы вошли под: " + user.Polzovateli.Roli.Nazvanie.ToString()); // Появляется окно информации
                    LoadForm(user.Polzovateli.Roli.Nazvanie.ToString());                           // И передается роль в метод загрузки страниц по ролям
                }
                else
                {
                    MessageBox.Show("Вы ввели неверно логин или пароль!");
                    countUnsuccessful++;
                }
            }
            else
            {
                MessageBox.Show("Введите данные заново!");
                countUnsuccessful++;
                if (countUnsuccessful > 3)
                {
                    GenerateCaptcha();
                }
            }


        }
        private void GenerateCaptcha()
        {
            txtboxCaptcha.Visibility = Visibility.Visible; // Показываем надпись и
            txtBlokCaptcha.Visibility = Visibility.Visible; // поле для ввода капчи
            panelCaptcha.Visibility = Visibility.Visible;
            Random random = new Random();
            int randmNum = random.Next(0, 3); // Генерируем случайное число от 1 до 3

            switch (randmNum)
            {
                case 1:
                    txtBlokCaptcha.Text = "ju2sT8Cbs"; // Если случайное число равно 1, выводим капчу в TextBlock
                    txtBlokCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 2:
                    txtBlokCaptcha.Text = "iNmK2cl"; // Если случайное число равно 2, выводим капчу в TextBlock
                    txtBlokCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 3:
                    txtBlokCaptcha.Text = "uOozGk95"; // Если случайное число равно 3, выводим капчу в TextBlock
                    txtBlokCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
            }

        }
        private void LoadForm(string _rele)
        {
            switch (_rele)
            {
                case "Администратор":
                    NavigationService.Navigate(new Client()); //Если роль пользователя "Администратор", переходим на страницу клиента
                    break;
            }
        }
    }
}
