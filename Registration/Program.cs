using HashPasswords;
using Registration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RestoranEntities CompEntities = new RestoranEntities();
            Console.WriteLine("Введите фамилию пользователя");
            string familiya = Console.ReadLine();
            Console.WriteLine("Введите имя пользователя");
            string imya = Console.ReadLine();
            Console.WriteLine("Введите отчество(если отчества нет, нажмите Enter");
            string otchestvo = Console.ReadLine();
            Console.WriteLine("Укажите id роли\n1- Повар \n2- Администратор \n3- Официант");
            int idRoli = Convert.ToInt32(Console.ReadLine());
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
            CompEntities.Polzovateli.Add(pvl);
            CompEntities.SaveChanges();

            var avt = new Model.Avtorizaciya()
            {
                IDPolzovatel = pvl.IDPolzovatelya,
                Login = login,
                Parol = hashpassword,

            };
            CompEntities.Avtorizaciya.Add(avt);
            CompEntities.SaveChanges();

            Console.WriteLine("Регистрации пользователя завершена");
            Console.WriteLine($"Логин пользователя: {login}\nПароль пользователя: {hashpassword}");
            Console.ReadKey();
        }
    }
}
