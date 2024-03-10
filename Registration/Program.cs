using HashPasswords;
using Registration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper helper = new Helper();
            Console.WriteLine("Введите фамилию пользователя");
            string familiya = Console.ReadLine();
            Console.WriteLine("Введите имя пользователя");
            string imya = Console.ReadLine();
            Console.WriteLine("Введите отчество(если отчества нет, нажмите Enter");
            string otchestvo = Console.ReadLine();
            int idRoli = 0;
            do
            {
                try
                {
                    Console.WriteLine("Укажите id роли\n1- Повар \n2- Администратор \n3- Официант");
                    idRoli = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Напишите число от 1 до 3!");
                }
            } while (idRoli < 1 && idRoli > 3);
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string parol = Console.ReadLine();
            HashPassword hasher = new HashPassword();
            string hashpassword = hasher.HashingPassword(parol);
            

            var pvl = new Model.Polzovateli()
            {
                Familiya= familiya,
                Imya = imya,
                Otchestvo= otchestvo,
                IDRoli= idRoli,
            };
            helper.CreateUsers(pvl);

            var avt = new Model.Avtorizaciya()
            {
                IDPolzovatel = pvl.IDPolzovatelya,
                Login = login,
                Parol = hashpassword,

            };
            helper.CreateAvtorizaciya(avt);
            Console.WriteLine("Регистрации пользователя завершена");
            Console.WriteLine($"Логин пользователя: {login}\nПароль пользователя: {hashpassword}");
            Console.ReadKey();
        }
    }
}
